using HungryPizzariaAPI.Application.Models.ItemPedido;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizzariaAPI.Application.Models.Pedido
{
    public class PedidoModel
    {
        [Required]
        public List<ItemPedidoModel> ItensPedido { get; set; }
        public int ClienteID { get; set; }
        public string CodPedido { get; set; }
        public decimal ValorTotal => ItensPedido.Sum(x => x.Pizzas.Sum(s => s.Valor));

    }
}
