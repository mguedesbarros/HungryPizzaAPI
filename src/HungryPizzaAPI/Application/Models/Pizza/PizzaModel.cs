using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizzariaAPI.Application.Models.Pizza
{
    public class PizzaModel
    {
        public int Id { get; set; }
        public string Sabor { get; set; }
        public decimal Valor { get; set; }
    }
}
