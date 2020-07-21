using HungryPizzariaAPI.Domain.Entities;
using HungryPizzariaAPI.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizzariaAPI.Infrastructure.Data.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private const string DefaultCodProduto = "CP00000-01";
        protected readonly PizzariaContext Context;
        protected readonly DbSet<Pedido> DbSet;

        public PedidoRepository(PizzariaContext context)
        {
            this.Context = context;
            this.DbSet = Context.Set<Pedido>();
        }

        public async Task<Pedido> Add(Pedido pedido)
        {
            if (pedido is null)
                throw new ArgumentNullException(nameof(pedido));

            if (string.IsNullOrWhiteSpace(pedido.CodPedido))
                pedido.CodPedido = await GetIncrementedCodPedido();

            DbSet.Add(pedido);

            return pedido;
        }

        public async Task<IList<Pedido>> GetAll()
        {
            var pizzas = await this.Context.Pizzas.ToListAsync();

            var result = await Context.Pedidos
                .Include(x => x.ItensPedido)
                .ToListAsync();

            var pedidos = new List<Pedido>();
            foreach (var (pedido, itensPedido) in from pedido in result
                                                  let itensPedido = new List<ItemPedido>()
                                                  select (pedido, itensPedido))
            {
                foreach (var item in pedido.ItensPedido)
                {
                    item.Pizzas.Add(pizzas.FirstOrDefault(x => x.Id == item.PizzaID1));

                    if (item.PizzaID2 != null)
                        item.Pizzas.Add(pizzas.FirstOrDefault(x => x.Id == item.PizzaID2));

                    itensPedido.Add(item);
                }

                pedido.ItensPedido = itensPedido;
                pedidos.Add(pedido);
            }

            return pedidos;
        }

        public async Task<Pedido> GetById(int id)
        {
            var pedido = await DbSet.FindAsync(id);
            if (pedido != null)
            {
                await Context.Entry(pedido).Collection(x => x.ItensPedido).LoadAsync();
                //await Context.Entry(ItemPedido).Collection(x => x.Pizzas).LoadAsync();
            }

            return pedido;
        }

        public void Delete(Pedido pedido)
        {
            DbSet.Remove(pedido);
        }

        public async Task<Pedido> GetByCodigo(string codigo)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.CodPedido == codigo);
        }

        private async Task<string> GetIncrementedCodPedido()
        {
            var codPedido = DefaultCodProduto;
            var ultimoCodPedido = await GetUltimoCodPedidoByDataCriacaoAsync();

            if (!string.IsNullOrEmpty(ultimoCodPedido))
            {
                var numeroSelecionado = ultimoCodPedido.Substring(2, 5);
                var codPedidoNumero = int.Parse(numeroSelecionado, CultureInfo.InvariantCulture);
                codPedido = $"CP{codPedidoNumero + 1:D5}-01";
            }

            return codPedido;
        }

        private async Task<string> GetUltimoCodPedidoByDataCriacaoAsync()
        {
            var ultimoPedido = await DbSet.OrderByDescending(o => o.DataCriacao).FirstOrDefaultAsync();
            return ultimoPedido?.CodPedido;
        }

        public async Task<IList<Pedido>> GetByClienteId(int id)
        {
            var pizzas = await this.Context.Pizzas.ToListAsync();

            var pedidos = await Context.Pedidos
                .Include(x => x.ItensPedido)
                .Where(x => x.ClienteID == id)
                .ToListAsync();

            return pedidos.Select(s => new Pedido
            {
                CodPedido = s.CodPedido,
                ItensPedido = s.ItensPedido.Select(s => new ItemPedido(s.Quantidade, s.QuantidadeSabores,
                       pizzas.Where(x => new[] { s.PizzaID1, s.PizzaID2 }.Contains(x.Id))
                       .ToList())
                   ).ToList()
            }).ToList();            
        }

        public async Task<Pedido> GetByCodPedido(string codPedido)
        {
            var pizzas = await this.Context.Pizzas.ToListAsync();

            var pedido = await Context.Pedidos
                .Include(x => x.ItensPedido)
                .FirstOrDefaultAsync(x => x.CodPedido == codPedido);

            pedido.ItensPedido = pedido.ItensPedido
                .Select(s => new ItemPedido(s.Quantidade, s.QuantidadeSabores,
                    pizzas.Where(x => new[] { s.PizzaID1, s.PizzaID2 }.Contains(x.Id))
                    .ToList())
                ).ToList();

            return pedido;
        }
    }
}
