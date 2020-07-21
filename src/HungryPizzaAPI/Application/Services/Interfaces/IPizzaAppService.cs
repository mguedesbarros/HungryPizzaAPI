using HungryPizzariaAPI.Application.Models.Pizza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizzariaAPI.Application.Services.Interfaces
{
    public interface IPizzaAppService
    {
        CreatePizzaResponse Create(CreatePizzaRequest request);
        UpdatePizzaResponse Update(UpdatePizzaRequest request);
        Task<IList<PizzaModel>> GetAll();
        PizzaModel GetById(int id);
        DeletePizzaResponse Delete(int id);
    }
}
