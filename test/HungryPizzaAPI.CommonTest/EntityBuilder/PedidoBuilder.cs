using HungryPizzariaAPI.Application.Models.ItemPedido;
using HungryPizzariaAPI.Application.Models.Pedido;
using HungryPizzariaAPI.Application.Models.Pizza;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HungryPizzaAPI.CommonTest.EntityBuilder
{
    public static class PedidoBuilder
    {
        public static async Task<IList<PedidoModel>> GetPedidosTest()
        {
            return await Task.Run(() => new List<PedidoModel>()
            {
                new PedidoModel
                {
                    ClienteID = 1,
                    ItensPedido = new List<ItemPedidoModel>
                    {
                        new ItemPedidoModel
                        {
                            QuantidadeSabores = 1,
                            Pizzas = new List<PizzaModel>
                            {
                                new PizzaModel
                                {
                                    Sabor = "Calabresa",
                                    Valor = 10.0M
                                }
                            }
                        }
                    }
                }
            });
        }

        public static async Task<PedidoModel> GetPedidoTest()
        {
            return await Task.Run(() => new PedidoModel
            {
                CodPedido = "CP00000-01",
                ClienteID = 1,
                ItensPedido = new List<ItemPedidoModel>
                {
                    new ItemPedidoModel
                    {
                        QuantidadeSabores = 1,
                        Pizzas = new List<PizzaModel>
                        {
                            new PizzaModel
                            {
                                Sabor = "Calabresa",
                                Valor = 10.0M
                            }
                        }
                    }
                }
            });
        }

        public static Task<CreatePedidoRequest> CreatePedidoNovoClienteRequest()
        {
            return Task.Run(() => new CreatePedidoRequest
            {
                Nome = "Marcelo",
                Telefone = "1199993333",
                Endereco = "Rua Nova",
                Numero = "100B",
                Bairro = "Jd Esperança",
                Cidade = "Barueri",
                ItensPedido = new List<ItemPedidoModel>
                {
                    new ItemPedidoModel
                    {
                        QuantidadeSabores = 1,
                        Pizzas = new List<PizzaModel>
                        {
                            new PizzaModel
                            {
                                Sabor = "Calabresa",
                                Valor = 10.0M
                            }
                        }
                    }
                }
            });
        }

        public static Task<CreatePedidoRequest> CreatePedidoClienteCadastradoRequest()
        {
            return Task.Run(() => new CreatePedidoRequest
            {
                ClienteID = 1,
                ItensPedido = new List<ItemPedidoModel>
                {
                    new ItemPedidoModel
                    {
                        QuantidadeSabores = 2,
                        PizzaID1 = 1,
                        PizzaID2 = 2
                    }
                }
            });
        }

        public static Task<CreatePedidoRequest> CreatePedidoItemMaior10Request()
        {
            return Task.Run(() => new CreatePedidoRequest
            {
                ClienteID = 1,
                ItensPedido = new List<ItemPedidoModel>
                {
                    new ItemPedidoModel
                    {
                        QuantidadeSabores = 2,
                        PizzaID1 = 1,
                        PizzaID2 = 2
                    },
                    new ItemPedidoModel
                    {
                        QuantidadeSabores = 1,
                        PizzaID1 = 2
                    },
                    new ItemPedidoModel
                    {
                        QuantidadeSabores = 1,
                        PizzaID1 = 1
                    },
                    new ItemPedidoModel
                    {
                        QuantidadeSabores = 2,
                        PizzaID1 = 4,
                        PizzaID2 = 5
                    },
                    new ItemPedidoModel
                    {
                        QuantidadeSabores = 2,
                        PizzaID1 = 1,
                        PizzaID2 = 2
                    },
                    new ItemPedidoModel
                    {
                        QuantidadeSabores = 2,
                        PizzaID1 = 1,
                        PizzaID2 = 2
                    },
                    new ItemPedidoModel
                    {
                        QuantidadeSabores = 2,
                        PizzaID1 = 1,
                        PizzaID2 = 2
                    },
                    new ItemPedidoModel
                    {
                        QuantidadeSabores = 2,
                        PizzaID1 = 1,
                        PizzaID2 = 2
                    },
                    new ItemPedidoModel
                    {
                        QuantidadeSabores = 2,
                        PizzaID1 = 1,
                        PizzaID2 = 2
                    },
                    new ItemPedidoModel
                    {
                        QuantidadeSabores = 2,
                        PizzaID1 = 1,
                        PizzaID2 = 2
                    },
                    new ItemPedidoModel
                    {
                        QuantidadeSabores = 2,
                        PizzaID1 = 1,
                        PizzaID2 = 2
                    },
                    new ItemPedidoModel
                    {
                        QuantidadeSabores = 2,
                        PizzaID1 = 1,
                        PizzaID2 = 2
                    }
                }

            });
        }

        public static CreatePedidoRequest CreatePedidoRequestInvalidModelState()
        {
            return new CreatePedidoRequest
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
