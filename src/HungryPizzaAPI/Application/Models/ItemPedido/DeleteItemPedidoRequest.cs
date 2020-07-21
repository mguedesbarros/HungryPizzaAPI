using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizzariaAPI.Application.Models.ItemPedido
{
    public class DeleteItemPedidoRequest
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string CodPedido { get; set; }
    }
}
