using HungryPizzariaAPI.Application.Models.Pizza;
using HungryPizzariaAPI.Application.Services.Interfaces;
using HungryPizzariaAPI.Domain.Entities;
using HungryPizzariaAPI.Domain.Interfaces.Repositories;
using HungryPizzariaAPI.Domain.Interfaces.Services;
using HungryPizzariaAPI.Infrastructure.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizzariaAPI.Application.Services
{
    public class PizzaAppService : IPizzaAppService
    {
        private readonly IPizzaRepository _repository;
        private readonly IPizzaService _service;
        private readonly IUnitOfWork _uow;

        public PizzaAppService(IPizzaRepository repository, 
                               IPizzaService service, 
                               IUnitOfWork uow)
        {
            _repository = repository;
            _service = service;
            _uow = uow;
        }
        public CreatePizzaResponse Create(CreatePizzaRequest request)
        {
            var pizza = request.ProjectedAs<Pizza>();

            var response = _service.Add(pizza);

            if (response.IsSuccess)
                _uow.Commit();

            return response.ProjectedAs<CreatePizzaResponse>();
        }

        public UpdatePizzaResponse Update(UpdatePizzaRequest request)
        {
            var pizza = request.ProjectedAs<Pizza>();

            var response = _service.Update(pizza);

            if (response.IsSuccess)
                _uow.Commit();

            return response.ProjectedAs<UpdatePizzaResponse>();
        }

        public DeletePizzaResponse Delete(int id)
        {
            var response = _service.Delete(id);

            if (response.IsSuccess)
                _uow.Commit();

            return response.ProjectedAs<DeletePizzaResponse>();
        }

        public async Task<IList<PizzaModel>> GetAll()
        {
            var response = await _repository.GetAll();

            return response.ProjectedAs<IList<PizzaModel>>();
        }

        public PizzaModel GetById(int id)
        {
            var response = _repository.GetById(id);

            return response.ProjectedAs<PizzaModel>();
        }        
    }
}
