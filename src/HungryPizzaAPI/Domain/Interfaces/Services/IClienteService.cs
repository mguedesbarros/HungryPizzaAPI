using HungryPizzariaAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizzariaAPI.Domain.Interfaces.Services
{
    public interface IClienteService
    {
        ResultEntity<Cliente> Create(Cliente cliente);
        ResultEntity<Cliente> Delete(int id);
        ResultEntity<Cliente> Update(Cliente cliente);
    }
}
