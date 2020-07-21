using HungryPizzariaAPI.Application.Models.Cliente;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HungryPizzaAPI.CommonTest.EntityBuilder
{
    public abstract class ClienteBuilder
    {
        public static async Task<IList<ClienteModel>> GetClientesTest()
        {
            return await Task.Run(() => new List<ClienteModel>()
            {
                new ClienteModel
                {
                    Id = 1,
                    Nome = "Marcelo",
                    Telefone = "1199993333",
                    Endereco = "Rua Nova",
                    Numero = "100B",
                    Complemento = "",
                    Bairro = "Jd Esperança",
                    Cidade = "Barueri",
                    CEP = "",
                    Email = ""
                }
            });
        }

        public static async Task<ClienteModel> GetClienteTest()
        {
            return await Task.Run(() => new ClienteModel
            {
                Id = 1,
                Nome = "Marcelo",
                Telefone = "1199993333",
                Endereco = "Rua Nova",
                Numero = "100B",
                Complemento = "",
                Bairro = "Jd Esperança",
                Cidade = "Barueri",
                CEP = "",
                Email = ""
            });
        }

        public static CreateClienteRequest CreateClienteRequest()
        {
            return new CreateClienteRequest
            {
                Nome = "Marcelo",
                Telefone = "1199993333",
                Endereco = "Rua Nova",
                Numero = "100B",
                Complemento = "",
                Bairro = "Jd Esperança",
                Cidade = "Barueri",
                CEP = "",
                Email = ""
            };
        }

        public static UpdateClienteRequest UpdateClienteRequest()
        {
            return new UpdateClienteRequest
            {
                Id = 1,
                Telefone = "1199993333",
                Endereco = "Rua Nova",
                Numero = "100B",
                Complemento = "",
                Bairro = "Jd Esperança",
                Cidade = "Barueri",
                CEP = "00133990",
                Email = "marcelo@gmail.com"
            };
        }

        public static CreateClienteRequest CreateClienteRequestInvalidModelState()
        {
            return new CreateClienteRequest
            {
                Telefone = "1199993333",
                Endereco = "Rua Nova",
                Numero = "100B",
                Complemento = "",
                Bairro = "Jd Esperança",
                Cidade = "Barueri",
                CEP = "00133990",
                Email = "marcelo@gmail.com"
            };
        }
    }
}
