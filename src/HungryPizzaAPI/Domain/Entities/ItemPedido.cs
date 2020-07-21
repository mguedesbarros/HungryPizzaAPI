using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizzariaAPI.Domain.Entities
{
    public class ItemPedido : BaseEntity
    {
        public ItemPedido() 
        {
            Pizzas = new List<Pizza>();
        }

        public ItemPedido(int quantidade, int quantidadeSabores, int pizzaId1, int? pizzaId2, List<Pizza> pizzas = null, int? pedidoId = null)
        {
            if (quantidade <= 0 || quantidade > 2) throw new ArgumentOutOfRangeException(nameof(quantidade));

            if (quantidadeSabores == 1 && pizzaId2 != null)
                throw new ArgumentOutOfRangeException(nameof(pizzaId2), "Escolher somente um sabor para a pizza");

            if (quantidadeSabores == 2 && pizzaId2 == null)
                throw new ArgumentOutOfRangeException(nameof(pizzaId2), "Necessário escolher o sabor da outra metade da pizza");

            Quantidade = quantidade;
            QuantidadeSabores = quantidadeSabores;
            PizzaID1 = pizzaId1;
            PizzaID2 = pizzaId2;
            ValorUnitario = GetValorUnitario(pizzaId1, pizzaId2, pizzas);
            PedidoID = pedidoId ?? 0;
        }

        public ItemPedido(int quantidade, int quantidadeSabores, List<Pizza> pizzas)
        {
            Quantidade = quantidade;
            QuantidadeSabores = quantidadeSabores;
            Pizzas = pizzas;
        }

        private static decimal GetValorUnitario(int pizzaId1, int? pizzaId2, List<Pizza> pizzas)
        {
            decimal valorUnitario = 0;

            if(pizzas != null)
            {
                if (pizzaId2 != null)
                    valorUnitario = pizzas.Where(x => new[] { pizzaId1, pizzaId2 }.Contains(x.Id)).Sum(s => s.Valor);
                else
                    valorUnitario = pizzas.Where(x => x.Id == pizzaId1).Sum(s => s.Valor);
            }

            return valorUnitario;
        }

        public ItemPedido AtualizarValorUnitario(ItemPedido item, List<Pizza> pizzas)
        {
            if (pizzas != null)
            {
                if (item.PizzaID2 != null)
                    item.ValorUnitario = pizzas.Where(x => new[] { item.PizzaID1, item.PizzaID2 }.Contains(x.Id)).Sum(s => s.Valor);
                else
                    item.ValorUnitario = pizzas.Where(x => x.Id == item.PizzaID1).Sum(s => s.Valor);
            }

            return item;
        }

        public int PedidoID { get; private set; }
        public int Quantidade { get; private set; }
        public decimal ValorUnitario { get; private set; }
        public int QuantidadeSabores { get; set; }
        public int PizzaID1 { get; private set; }
        public int? PizzaID2 { get; private set; }
        public string CodPedido { get; set; }
        public virtual Pedido Pedido { get; set; }
        public virtual List<Pizza> Pizzas { get; set; }
    }
}
