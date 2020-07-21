using HungryPizzariaAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizzariaAPI.Domain.Interfaces.Repositories
{
    public interface IPizzaRepository
    {
        void Add(Pizza pizza);
        void Update(Pizza pizza);
        void Delete(Pizza id);
        Task<IList<Pizza>> GetAll();
        Pizza GetById(int id);
        Pizza GetBySabor(string sabor);
    }
}
