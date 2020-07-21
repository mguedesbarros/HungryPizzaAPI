using HungryPizzariaAPI.Application.Models.Pizza;
using HungryPizzariaAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizzariaAPI.Application.Models.ItemPedido
{
    public class ItemPedidoModel
    {
        public ItemPedidoModel()
        {
            Quantidade = 1;
        }
        public int PedidoID { get; set; }
        public int Quantidade { get; private set; }
        public int QuantidadeSabores { get; set; }
        public int PizzaID1 { get; set; }
        public int? PizzaID2 { get; set; }
        public decimal ValorUnitario { get; set; }
        public List<PizzaModel> Pizzas { get; set; }
    }
}
