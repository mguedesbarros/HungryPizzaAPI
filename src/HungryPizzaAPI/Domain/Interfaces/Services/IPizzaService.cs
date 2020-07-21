using HungryPizzariaAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizzariaAPI.Domain.Interfaces.Services
{
    public interface IPizzaService
    {
        ResultEntity<Pizza> Add(Pizza pizza);
        ResultEntity<Pizza> Delete(int id);
        ResultEntity<Pizza> Update(Pizza pizza);
    }
}
