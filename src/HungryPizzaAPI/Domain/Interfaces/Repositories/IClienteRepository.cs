using HungryPizzariaAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizzariaAPI.Domain.Interfaces.Repositories
{
    public interface IClienteRepository
    {
        void Add(Cliente cliente);
        void Update(Cliente cliente);
        void Delete(Cliente cliente);
        Task<IList<Cliente>> GetAll();
        Cliente GetById(int id);
        Cliente GetByTelefone(string telefone);
    }
}
