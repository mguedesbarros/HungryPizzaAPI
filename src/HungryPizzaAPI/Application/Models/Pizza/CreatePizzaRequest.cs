using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizzariaAPI.Application.Models.Pizza
{
    public class CreatePizzaRequest
    {
        [Required]
        [MaxLength(200, ErrorMessage = "Número máximo de caracteres é de 200")]
        public string Sabor { get; set; }
        [Required(ErrorMessage = "Campo Valor é obrigatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Valor precisa ser maior que zero.")]
        public decimal Valor { get; set; }
    }
}
