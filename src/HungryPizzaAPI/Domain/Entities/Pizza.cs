using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizzariaAPI.Domain.Entities
{
    public class Pizza : BaseEntity
    {
        public Pizza() { }
        public Pizza(string sabor, decimal valor)
        {
            Sabor = sabor;
            Valor = valor;
            DataCriacao = DateTime.Now;
            DataAtualizacao = DataCriacao;
        }

        internal void Update(int id, string sabor, decimal valor)
        {
            Id = id;
            Sabor = sabor;
            Valor = valor;
            DataAtualizacao = DateTime.Now;
        }

        public string Sabor { get; private set; }
        public decimal Valor { get; private set; }
        public virtual ItemPedido ItemPedido { get; set; }
    }
}