using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizzariaAPI.Application.Models.Cliente
{
    public class CreateClienteRequest
    {
        [Required]
        [MaxLength(200, ErrorMessage = "Número máximo de caracteres é de 200")]
        public string Nome { get; set; }
        [Required]
        [MaxLength(15, ErrorMessage = "Número máximo de caracteres é de 15")]
        public string Telefone { get; set; }
        [MaxLength(50, ErrorMessage = "Número máximo de caracteres é de 50")]
        public string Email { get; set; }
        [Required]
        [MaxLength(200, ErrorMessage = "Número máximo de caracteres é de 200")]
        public string Endereco { get; set; }
        [Required]
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
    }
}
