using HungryPizzariaAPI.Domain.Entities;
using HungryPizzariaAPI.Domain.Interfaces.Repositories;
using HungryPizzariaAPI.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizzariaAPI.Domain.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;
        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }
        public ResultEntity<Cliente> Create(Cliente cliente)
        {
            try
            {
                var _cliente = _repository.GetByTelefone(cliente.Telefone);

                if (_cliente != null)
                    return ResultEntity<Cliente>.Fail(cliente, $"Já existe uma Cliente com o telefone - {cliente.Telefone}");

                _repository.Add(cliente);

                return ResultEntity<Cliente>.Success(cliente);
            }
            catch (Exception e)
            {
                return ResultEntity<Cliente>.Fail(cliente, $"Ocorreu algum erro na criação da Cliente - {e.Message}");
            }
        }

        public ResultEntity<Cliente> Delete(int id)
        {
            var Cliente = new Cliente();

            try
            {
                Cliente = _repository.GetById(id);

                if (Cliente == null)
                    return ResultEntity<Cliente>.Fail(Cliente, $"Cliente não existe");

                _repository.Delete(Cliente);

                return ResultEntity<Cliente>.Success(Cliente);
            }
            catch (Exception e)
            {
                return ResultEntity<Cliente>.Fail(Cliente, $"Ocorreu algum erro na exclusão da Cliente - {e.Message}");
            }
        }       

        public ResultEntity<Cliente> Update(Cliente clinete)
        {
            try
            {
                _repository.Update(clinete);

                return ResultEntity<Cliente>.Success(clinete);
            }
            catch (Exception e)
            {
                return ResultEntity<Cliente>.Fail(clinete, $"Ocorreu algum erro na alteração do Cliente - {e.Message}");
            }
        }
    }
}
