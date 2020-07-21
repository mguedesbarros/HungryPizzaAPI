using HungryPizzariaAPI.Domain.Entities;
using HungryPizzariaAPI.Domain.Interfaces.Repositories;
using HungryPizzariaAPI.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizzariaAPI.Domain.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly IPizzaRepository _repository;
        public PizzaService(IPizzaRepository repository)
        {
            _repository = repository;
        }
        public ResultEntity<Pizza> Add(Pizza pizza)
        {
            try
            {
                var _pizza = _repository.GetBySabor(pizza.Sabor);

                if (_pizza != null)
                    return ResultEntity<Pizza>.Fail(pizza, $"Já existe uma pizza com o sabor - {pizza.Sabor}");

                _repository.Add(pizza);

                return ResultEntity<Pizza>.Success(pizza);
            }
            catch (Exception e)
            {
                return ResultEntity<Pizza>.Fail(pizza, $"Ocorreu algum erro na criação da pizza - {e.Message}");
            }
        }

        public ResultEntity<Pizza> Delete(int id)
        {
            var pizza = new Pizza();

            try
            {
                pizza = _repository.GetById(id);

                if (pizza == null)
                    return ResultEntity<Pizza>.Fail(pizza, $"Pizza não existe");

                _repository.Delete(pizza);

                return ResultEntity<Pizza>.Success(pizza);
            }
            catch (Exception e)
            {
                return ResultEntity<Pizza>.Fail(pizza, $"Ocorreu algum erro na exclusão da pizza - {e.Message}");
            }
        }

        public ResultEntity<Pizza> Update(Pizza pizza)
        {
            try
            {
                pizza.Update(pizza.Id, pizza.Sabor, pizza.Valor);

                _repository.Update(pizza);

                return ResultEntity<Pizza>.Success(pizza);
            }
            catch (Exception e)
            {
                return ResultEntity<Pizza>.Fail(pizza, $"Ocorreu algum erro na alteração da pizza - {e.Message}");
            }
        }
    }
}
