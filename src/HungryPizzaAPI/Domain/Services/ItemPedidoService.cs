using HungryPizzariaAPI.Domain.Entities;
using HungryPizzariaAPI.Domain.Interfaces.Repositories;
using HungryPizzariaAPI.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizzariaAPI.Domain.Services
{
    public class ItemPedidoService : IItemPedidoService
    {
        private readonly IItemPedidoRepository _repository;
        private readonly IPizzaRepository _pizzaRepository;
        public ItemPedidoService(IItemPedidoRepository repository,
                                 IPizzaRepository pizzaRepository)
        {
            _repository = repository;
            _pizzaRepository = pizzaRepository;
        }

        public async Task<ResultEntity<ItemPedido>> Add(ItemPedido itemPedido)
        {
            try
            {
                var itensPedido = await _repository.GetByPedidoId(itemPedido.PedidoID);

                if (itensPedido.Count() == 10)
                    return ResultEntity<ItemPedido>.Fail(itemPedido, $"Só é permitido 10 itens por pedido - {itemPedido.CodPedido}");

                var pizzas = await _pizzaRepository.GetAll();
                if (!pizzas.Any())
                    throw new ArgumentNullException(nameof(itemPedido), "Nenhuma pizza cadastrada!");

                itemPedido = new ItemPedido(1, itemPedido.QuantidadeSabores, itemPedido.PizzaID1, itemPedido.PizzaID2, pizzas.ToList(), itemPedido.PedidoID);

                itemPedido = await _repository.Create(itemPedido);

                return ResultEntity<ItemPedido>.Success(itemPedido);
            }
            catch (Exception e)
            {
                return ResultEntity<ItemPedido>.Fail(itemPedido, $"Ocorreu algum erro na criação do ItemPedido - {e.Message}");
            }
        }

        public async Task<ResultEntity<ItemPedido>> AddRange(List<ItemPedido> pedidos)
        {
            try
            {
                var pedidoId = pedidos.FirstOrDefault().PedidoID;
                var codPedido = pedidos.FirstOrDefault().CodPedido;

                var itensPedido = await _repository.GetByPedidoId(pedidoId);

                if (itensPedido.Count() == 10)
                    return ResultEntity<ItemPedido>.Fail(pedidos.FirstOrDefault(), $"Só é permitido 10 itens por pedido - {codPedido}");

                _repository.AddRange(pedidos);

                return ResultEntity<ItemPedido>.Success(pedidos.FirstOrDefault());
            }
            catch (Exception e)
            {
                return ResultEntity<ItemPedido>.Fail(pedidos.FirstOrDefault(), $"Ocorreu algum erro na criação do ItemPedido - {e.Message}");
            }
        }

        public async Task<ResultEntity<ItemPedido>> Delete(int id)
        {
            try
            {
                var itemPedido = await _repository.GetById(id);

                if (itemPedido == null)
                    return ResultEntity<ItemPedido>.Fail(itemPedido, $"Item Pedido não existe");

                _repository.Delete(itemPedido);

                return ResultEntity<ItemPedido>.Success(itemPedido);
            }
            catch (Exception e)
            {
                return ResultEntity<ItemPedido>.Fail(new ItemPedido(), $"Ocorreu algum erro na exclusão do Item Pedido - {e.Message}");
            }
        }

        public ResultEntity<ItemPedido> Update(ItemPedido itemPedido)
        {
            try
            {
                //pedido.Update(pedido.Id, pedido.Sabor, pedido.Valor);

                _repository.Update(itemPedido);

                return ResultEntity<ItemPedido>.Success(itemPedido);
            }
            catch (Exception e)
            {
                return ResultEntity<ItemPedido>.Fail(itemPedido, $"Ocorreu algum erro na alteração do item pedido - {e.Message}");
            }
        }
    }
}
