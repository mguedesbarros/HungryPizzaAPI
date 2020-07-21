using HungryPizzariaAPI.Application.Models.ItemPedido;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HungryPizzaAPI.CommonTest.EntityBuilder
{
    public static class ItemPedidoBuilder
    {
        public static async Task<IList<ItemPedidoModel>> GetItensPedidoTest()
        {
            return await Task.Run(() => new List<ItemPedidoModel>()
            {
                new ItemPedidoModel
                {
                    PedidoID = 1,
                    QuantidadeSabores = 2,
                    PizzaID1 = 2,
                    PizzaID2 = 3
                }
            });
        }

        public static async Task<ItemPedidoModel> GetItemPedidoTest()
        {
            return await Task.Run(() => new ItemPedidoModel
            {
                PedidoID = 1,
                QuantidadeSabores = 2,
                PizzaID1 = 2,
                PizzaID2 = 3
            });
        }

        public static Task<CreateItemPedidoRequest> CreateItemPedidoRequest()
        {
            return Task.Run(() => new CreateItemPedidoRequest
            {
                PedidoID = 1,
                CodPedido = "",
                QuantidadeSabores = 2,
                PizzaID1 = 2,
                PizzaID2 = 3
            });
        }

        //public static Task<CreateItemPedidoRequest> CreateItemPedidoRequest()
        //{
        //    return Task.Run(() => new CreateItemPedidoRequest
        //    {
        //        PedidoID = 1,
        //        CodPedido = "",
        //        QuantidadeSabores = 2,
        //        PizzaID1 = 2,
        //        PizzaID2 = 3
        //    });
        //}

        public static Task<UpdateItemPedidoRequest> UpdateItemPedidoRequest()
        {
            return Task.Run(() => new UpdateItemPedidoRequest
            {
                Id = 1,
                CodPedido = "",
                QuantidadeSabores = 1,
                PizzaID1 = 5,
                PizzaID2 = null
            });
        }


    }
}
