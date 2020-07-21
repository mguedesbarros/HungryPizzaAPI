using HungryPizzariaAPI.Application.Models.Pedido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizzariaAPI.Application.Services.Interfaces
{
    public interface IPedidoAppService
    {
        Task<CreatePedidoResponse> Create(CreatePedidoRequest request);
        Task<IList<PedidoModel>> GetAll();
        Task<IList<PedidoModel>> GetByClienteId(int id);
        Task<PedidoModel> GetByCodPedido(string codPedido);
        Task<DeletePedidoResponse> Delete(int id);
    }
}
