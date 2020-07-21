using HungryPizzariaAPI.Domain.Entities;
using HungryPizzariaAPI.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizzariaAPI.Infrastructure.Data.Repositories
{
    public class ItemPedidoRepository : IItemPedidoRepository
    {
        protected readonly PizzariaContext Context;
        protected readonly DbSet<ItemPedido> DbSet;

        public ItemPedidoRepository(PizzariaContext context)
        {
            this.Context = context;
            this.DbSet = Context.Set<ItemPedido>();
        }
        public async Task<ItemPedido> Create(ItemPedido itemPedido)
        {
            if (itemPedido is null)
                throw new ArgumentNullException(nameof(itemPedido));

            await DbSet.AddAsync(itemPedido);

            return itemPedido;
        }

        public void AddRange(List<ItemPedido> itensPedido)
        {
            if (itensPedido is null)
                throw new ArgumentNullException(nameof(itensPedido));

            DbSet.AddRange(itensPedido);
        }

        public void Delete(ItemPedido id)
        {
            DbSet.Remove(id);
        }

        public async Task<ItemPedido> GetById(int id)
        {
            return await DbSet.FindAsync(id);            
        }

        public async Task<List<ItemPedido>> GetByPedidoId(int id)
        {
            return await DbSet.Where(x => x.PedidoID == id).ToListAsync();
        }

        public void Update(ItemPedido itemPedido)
        {
            Context.Entry(itemPedido).State = EntityState.Modified;
            Context.Entry(itemPedido).Property(x => x.DataCriacao).IsModified = false;

            DbSet.Update(itemPedido);
        }
    }
}
