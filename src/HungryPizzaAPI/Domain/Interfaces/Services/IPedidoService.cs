using HungryPizzariaAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizzariaAPI.Domain.Interfaces.Services
{
    public interface IPedidoService
    {
        Task<ResultEntity<Pedido>> Create(Pedido pedido);
        Task<ResultEntity<Pedido>> Delete(int id);
    }
}
