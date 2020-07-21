using HungryPizzariaAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizzariaAPI.Domain.Interfaces.Repositories
{
    public interface IItemPedidoRepository
    {
        Task<ItemPedido> Create(ItemPedido itemPedido);
        void AddRange(List<ItemPedido> itensPedido);
        void Update(ItemPedido itemPedido);
        void Delete(ItemPedido id);
        Task<ItemPedido> GetById(int id);
        Task<List<ItemPedido>> GetByPedidoId(int id);
    }
}
