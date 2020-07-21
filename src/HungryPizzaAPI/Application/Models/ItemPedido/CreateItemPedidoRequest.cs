using HungryPizzariaAPI.Application.Models.Pizza;
using HungryPizzariaAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizzariaAPI.Application.Models.ItemPedido
{
    public class CreateItemPedidoRequest
    {
        [Required]
        public int PedidoID { get; set; }
        public string CodPedido { get; set; }
        [Required]
        public int QuantidadeSabores { get; set; }
        [Required]
        public int PizzaID1 { get; set; }
        public int? PizzaID2 { get; set; }
    }
}
