using HungryPizzariaAPI.Application.Models.ItemPedido;
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
    public class ItemPedidoAppService : IItemPedidoAppService
    {
        private readonly IItemPedidoService _service;
        private readonly IItemPedidoRepository _repository;
        
        private readonly IUnitOfWork _uow;

        public ItemPedidoAppService(IItemPedidoService service,
                                    IItemPedidoRepository repository,
                                    IUnitOfWork uow)
        {
            _service = service;
            _repository = repository;
            _uow = uow;

        }

        public async Task<CreateItemPedidoResponse> Create(CreateItemPedidoRequest request)
        {
            var itemPedido = request.ProjectedAs<ItemPedido>();
            
            var response = await _service.Add(itemPedido);

            if (response.IsSuccess)
                _uow.Commit();

            return response.ProjectedAs<CreateItemPedidoResponse>();

        }

        public async Task<DeleteItemPedidoResponse> Delete(int id)
        {
            var response = await _service.Delete(id);

            if (response.IsSuccess)
                _uow.Commit();

            return response.ProjectedAs<DeleteItemPedidoResponse>();
        }

        public async Task<IList<ItemPedidoModel>> GetByPedidoId(int id)
        {
            var response = await _repository.GetByPedidoId(id);

            return response.ProjectedAs<IList<ItemPedidoModel>>();
        }

        public async Task<UpdateItemPedidoResponse> Update(UpdateItemPedidoRequest request)
        {
            var itemPedido = await _repository.GetById(request.Id);

            var response = _service.Update(itemPedido);

            if (response.IsSuccess)
                _uow.Commit();

            return response.ProjectedAs<UpdateItemPedidoResponse>();

        }
    }
}
