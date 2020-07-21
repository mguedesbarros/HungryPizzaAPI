using HungryPizzariaAPI.Application.Models.Pizza;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HungryPizzariaAPI.CommonTest.EntityBuilder
{
    public abstract class PizzaBuilder
    {
        public static async Task<IList<PizzaModel>> GetPizzasTest()
        {
            return await Task.Run(() => new List<PizzaModel>()
            {
                new PizzaModel
                {
                    Id = 8,
                    Sabor = "Calabresa-Test",
                    Valor = 42.50M
                }
            });
        }

        public static async Task<PizzaModel> GetPizzaTest()
        {
            return await Task.Run(() => new PizzaModel
            {
                Id = 8,
                Sabor = "Calabresa-Test",
                Valor = 42.50M
            });
        }

        public static CreatePizzaRequest CreatePizzaRequest()
        {
            return new CreatePizzaRequest
            {
                Sabor = "Calabresa-Test",
                Valor = 42.50M
            };
        }

        public static UpdatePizzaRequest UpdatePizzaRequest()
        {
            return new UpdatePizzaRequest
            {
                Id = 8,
                Sabor = "Calabresa-Test-Update",
                Valor = 44.50M
            };
        }

    }
}
