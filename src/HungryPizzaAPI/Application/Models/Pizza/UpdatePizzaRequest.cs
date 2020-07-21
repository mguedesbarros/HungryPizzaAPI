using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizzariaAPI.Application.Models.Pizza
{
    public class UpdatePizzaRequest
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(200, ErrorMessage = "Número máximo de caracteres é de 200")]
        public string Sabor { get; set; }
        [Required]
        public decimal Valor { get; set; }
    }
}
