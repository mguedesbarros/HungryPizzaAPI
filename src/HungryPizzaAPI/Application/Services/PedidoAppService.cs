using HungryPizzariaAPI.Application.Models.Cliente;
using HungryPizzariaAPI.Application.Models.Pedido;
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
    public class PedidoAppService : IPedidoAppService
    {
        private readonly IClienteService _clienteService;
        private readonly IClienteRepository _clienteRepository;
        private readonly IPedidoRepository _repository;
        private readonly IPizzaRepository _pizzaRepository;
        private readonly IPedidoService _service;
        private readonly IUnitOfWork _uow;

        public PedidoAppService(IPedidoRepository repository,
                                IClienteRepository clienteRepository,
                                IPedidoService service,
                                IClienteService clienteService,
                                IPizzaRepository pizzaRepository,
                                IUnitOfWork uow)
        {
            _repository = repository;
            _clienteRepository = clienteRepository;
            _service = service;
            _pizzaRepository = pizzaRepository;
            _clienteService = clienteService;
            _uow = uow;

        }

        public async Task<CreatePedidoResponse> Create(CreatePedidoRequest request)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            var clienteId = request.ClienteID;

            if (clienteId == null)
            {
                clienteId = CreateCliente(request);
            }

            var pedido = request.ProjectedAs<Pedido>();
            pedido.SetClienteId(clienteId.Value);

            var response = await _service.Create(pedido);

            if (response.IsSuccess)
                _uow.Commit();

            return response.ProjectedAs<CreatePedidoResponse>();
        }

        public async Task<DeletePedidoResponse> Delete(int id)
        {
            var response = await _service.Delete(id);

            if (response.IsSuccess)
                _uow.Commit();

            return response.ProjectedAs<DeletePedidoResponse>();
        }

        public async Task<IList<PedidoModel>> GetAll()
        {
            var response = await _repository.GetAll();

            return response.ProjectedAs<IList<PedidoModel>>();
        }

        public async Task<IList<PedidoModel>> GetByClienteId(int id)
        {
            var response = await _repository.GetByClienteId(id);

            return response.ProjectedAs<IList<PedidoModel>>();
        }

        public async Task<PedidoModel> GetByCodPedido(string codPedido)
        {
            var response = await _repository.GetByCodPedido(codPedido);

            return response.ProjectedAs<PedidoModel>();
        }

        private int? CreateCliente(CreatePedidoRequest request)
        {
            int? clienteId;
            if (string.IsNullOrEmpty(request.Telefone))
                throw new ArgumentNullException(nameof(request.Telefone), "Telefone é obrigatorio");

            if (string.IsNullOrEmpty(request.Nome))
                throw new ArgumentNullException(nameof(request.Nome), "Nome é obrigatorio");

            if (string.IsNullOrEmpty(request.Endereco))
                throw new ArgumentNullException(nameof(request.Endereco), "Endereco é obrigatorio");

            if (string.IsNullOrEmpty(request.Numero))
                throw new ArgumentNullException(nameof(request.Numero), "Numero é obrigatorio");

            var resp = _clienteService.Create(new
                Cliente(request.Nome,
                        request.Telefone,
                        request.Email,
                        request.Endereco,
                        request.Numero,
                        request.Complemento,
                        request.Bairro,
                        request.Cidade,
                        request.CEP));

            if (resp.IsSuccess)
            {
                _uow.Commit();

                var cliente = _clienteRepository.GetByTelefone(request.Telefone);

                if (cliente != null)
                    clienteId = cliente.Id;
                else
                    throw new ArgumentNullException(nameof(request), "Ocorreu algum erro ao gerar novo cliente");
            }
            else
                throw new ArgumentNullException(nameof(request), "Ocorreu algum erro ao gerar novo cliente");

            return clienteId;
        }
    }
}
