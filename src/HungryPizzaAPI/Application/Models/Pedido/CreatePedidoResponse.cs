using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizzariaAPI.Application.Models.Pedido
{
    public class CreatePedidoResponse : BaseResponse
    {
        public string CodPedido { get; set; }
    }
}
