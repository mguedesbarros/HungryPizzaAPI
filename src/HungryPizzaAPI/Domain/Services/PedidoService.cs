using HungryPizzariaAPI.Domain.Entities;
using HungryPizzariaAPI.Domain.Interfaces.Repositories;
using HungryPizzariaAPI.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizzariaAPI.Domain.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _repository;
        private readonly IPizzaRepository _pizzaRepository;
        public PedidoService(IPedidoRepository repository,
                             IPizzaRepository pizzaRepository)
        {
            _repository = repository;
            _pizzaRepository = pizzaRepository;
        }
        public async Task<ResultEntity<Pedido>> Create(Pedido pedido)
        {
            try
            {
                var _pedido = await _repository.GetByCodigo(pedido.CodPedido);

                if (_pedido != null)
                    return ResultEntity<Pedido>.Fail(pedido, $"Já existe um pedido com esse código - {pedido.CodPedido}");
                
                if (!pedido.ItensPedido.Any())
                    throw new ArgumentNullException(nameof(pedido), "Necessário pelo menos 1 item de pedido.");

                if (pedido.ItensPedido.Count() > 10)
                    throw new ArgumentNullException(nameof(pedido.ItensPedido), "Máximo de items por pedido é 10");

                var pizzas = await _pizzaRepository.GetAll();
                if (!pizzas.Any())
                    throw new ArgumentNullException(nameof(pedido.ItensPedido), "Nenhuma pizza cadastrada!");

                pedido.ItensPedido = (from item in pedido.ItensPedido
                                      select new ItemPedido().AtualizarValorUnitario(item, pizzas.ToList())).ToList();

                pedido = await _repository.Add(pedido);

                return ResultEntity<Pedido>.Success(pedido);
            }
            catch (Exception e)
            {
                return ResultEntity<Pedido>.Fail(pedido, $"Ocorreu algum erro na criação do pedido - {e.Message}");
            }
        }
        public async Task<ResultEntity<Pedido>> Delete(int id)
        {
            var pedido = new Pedido();

            try
            {
                pedido = await _repository.GetById(id);

                if (pedido == null)
                    return ResultEntity<Pedido>.Fail(pedido, $"Pedido não existe");

                _repository.Delete(pedido);

                return ResultEntity<Pedido>.Success(pedido);
            }
            catch (Exception e)
            {
                return ResultEntity<Pedido>.Fail(pedido, $"Ocorreu algum erro na exclusão do Pedido - {e.Message}");
            }
        }

        
    }
}
