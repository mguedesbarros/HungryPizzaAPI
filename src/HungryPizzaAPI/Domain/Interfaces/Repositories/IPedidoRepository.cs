using HungryPizzariaAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizzariaAPI.Domain.Interfaces.Repositories
{
    public interface IPedidoRepository
    {
        Task<Pedido> Add(Pedido pedido);
        void Delete(Pedido id);
        Task<IList<Pedido>> GetAll();
        Task<IList<Pedido>> GetByClienteId(int id);
        Task<Pedido> GetByCodPedido(string codPedido);
        Task<Pedido> GetById(int id);
        Task<Pedido> GetByCodigo(string codigo);
    }
}
