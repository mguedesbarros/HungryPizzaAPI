using HungryPizzariaAPI.Application.Models.ItemPedido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizzariaAPI.Application.Services.Interfaces
{
    public interface IItemPedidoAppService
    {
        Task<CreateItemPedidoResponse> Create(CreateItemPedidoRequest request);
        Task<UpdateItemPedidoResponse> Update(UpdateItemPedidoRequest request);
        Task<DeleteItemPedidoResponse> Delete(int id);
        Task<IList<ItemPedidoModel>> GetByPedidoId(int id);
    }
}
