using HungryPizzariaAPI.Application.Models.Cliente;
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
    public class ClienteAppService : IClienteAppService
    {
        private readonly IClienteRepository _repository;
        private readonly IClienteService _service;
        private readonly IUnitOfWork _uow;

        public ClienteAppService(IClienteRepository repository,
                                 IClienteService service, 
                                 IUnitOfWork uow)
        {
            _repository = repository;
            _service = service;
            _uow = uow;
        }

        public CreateClienteResponse Create(CreateClienteRequest request)
        {
            var cliente = request.ProjectedAs<Cliente>();

            var response = _service.Create(cliente);

            if (response.IsSuccess)
                _uow.Commit();

            return response.ProjectedAs<CreateClienteResponse>();
        }

        public DeleteClienteResponse Delete(int id)
        {
            var response = _service.Delete(id);

            if (response.IsSuccess)
                _uow.Commit();

            return response.ProjectedAs<DeleteClienteResponse>();
        }
        public UpdateClienteResponse Update(UpdateClienteRequest request)
        {
            var cliente = request.ProjectedAs<Cliente>();

            var response = _service.Update(cliente);

            if (response.IsSuccess)
                _uow.Commit();

            return response.ProjectedAs<UpdateClienteResponse>();
        }

        public async Task<IList<ClienteModel>> GetAll()
        {
            var response = await _repository.GetAll();

            return response.ProjectedAs<IList<ClienteModel>>();
        }

        public ClienteModel GetById(int id)
        {
            var response = _repository.GetById(id);

            return response.ProjectedAs<ClienteModel>();
        }

        
    }
}
