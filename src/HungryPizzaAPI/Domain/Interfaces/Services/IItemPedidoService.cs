using HungryPizzariaAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizzariaAPI.Domain.Interfaces.Services
{
    public interface IItemPedidoService
    {
        Task<ResultEntity<ItemPedido>> Add(ItemPedido pedido);
        Task<ResultEntity<ItemPedido>> AddRange(List<ItemPedido> pedidos);
        Task<ResultEntity<ItemPedido>> Delete(int id);
        ResultEntity<ItemPedido> Update(ItemPedido pedido);
    }
}
