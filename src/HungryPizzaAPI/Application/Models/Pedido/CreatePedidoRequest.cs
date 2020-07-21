using HungryPizzariaAPI.Application.Models.ItemPedido;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizzariaAPI.Application.Models.Pedido
{
    public class CreatePedidoRequest
    {
        public int? ClienteID { get; set; }
        [MaxLength(200, ErrorMessage = "Número máximo de caracteres é de 200")]
        public string Nome { get; set; }
        [MaxLength(15, ErrorMessage = "Número máximo de caracteres é de 15")]
        public string Telefone { get; set; }
        [MaxLength(15, ErrorMessage = "Número máximo de caracteres é de 15")]
        public string Email { get; set; }
        [MaxLength(200, ErrorMessage = "Número máximo de caracteres é de 200")]
        public string Endereco { get; set; }
        [MaxLength(10, ErrorMessage = "Número máximo de caracteres é de 10")]
        public string Numero { get; set; }
        [MaxLength(20, ErrorMessage = "Número máximo de caracteres é de 20")]
        public string Complemento { get; set; }
        [MaxLength(100, ErrorMessage = "Número máximo de caracteres é de 100")]
        public string Bairro { get; set; }
        [MaxLength(100, ErrorMessage = "Número máximo de caracteres é de 100")]
        public string Cidade { get; set; }
        [MaxLength(8, ErrorMessage = "Número máximo de caracteres é de 8")]
        public string CEP { get; set; }
        [Required]
        public List<ItemPedidoModel> ItensPedido { get; set; }        
    }
}
