using HungryPizzariaAPI.Domain.Entities;
using HungryPizzariaAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HungryPizzariaAPI.IntegrationTest
{
    public class DataGenerator
    {
        public static void Initialize(PizzariaContext context)
        {

            if (context.Pizzas.Any() &&
                context.Pedidos.Any() &&
                context.Clientes.Any())
                return;

            var pizzas = new List<Pizza>
            {
                new Pizza("3 Queijos", 50.0M),
                new Pizza("Frango com requeijão", 59.99M),
                new Pizza("Mussarela", 42.50M),
                new Pizza("Calabresa", 42.50M),
                new Pizza("Pepperoni", 55.0M),
                new Pizza("Portuguesa", 45.0M),
                new Pizza("Veggie", 59.99M)
            };
            context.Pizzas.AddRange(pizzas);

            context.Clientes.Add(new Cliente("João", "1122229999", "", "Rua Joao Ferreiro", "100", "", "Jd Tupanci", "Barueri", ""));

            var pedido = new Pedido(1, "CP00000-01", new List<ItemPedido>
            {
                new ItemPedido(1, 1, 1, null, pizzas, null)
            });

            context.Pedidos.Add(pedido);

            context.SaveChanges();

        }
    }
}
