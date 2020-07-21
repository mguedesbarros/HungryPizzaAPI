using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizzariaAPI.Domain.Entities
{
    public class Cliente : BaseEntity
    {
        public Cliente() { }
        public Cliente(string nome, 
            string telefone, 
            string email, 
            string endereco,
            string numero,
            string complemento,
            string bairro, 
            string cidade, 
            string cep)
        {
            Nome = nome;
            Telefone = telefone;
            Email = email;
            Endereco = endereco;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            CEP = cep;
            DataCriacao = DateTime.Now;
            DataAtualizacao = DataCriacao;
        }

        internal void Atualizar(string telefone, 
            string email, 
            string endereco,
            string numero,
            string complemento,
            string bairro, 
            string cidade, 
            string cep)
        {
            Telefone = telefone;
            Email = email;
            Endereco = endereco;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            CEP = cep;
            DataAtualizacao = DateTime.Now;
        }

        public string Nome { get; private set; }
        public string Telefone { get; private set; }
        public string Email { get; private set; }
        public string Endereco { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string CEP { get; private set; }        
        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}
