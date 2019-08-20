using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Projekt.Models
{
     public class Bill : BaseEntity
    {
        
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Ovo polje je obavezno!")]
        [Column(TypeName = "decimal(10, 2)")]
        public Decimal Tax { get; set; }

        [Required(ErrorMessage = "Ovo polje je obavezno!")]
        [Column(TypeName = "decimal(10, 2)")]
        public Decimal Amount { get; set; }


        [Required(ErrorMessage = "Ovo polje je obavezno ")]
        [MaxLength(10, ErrorMessage = "Max duljina je 10 znamenaka.")]
        [ MinLength(1, ErrorMessage = "Max duljina je 10 znamenaka.")]
        public string Currency { get; set; }

        [Required(ErrorMessage = "Ovo polje je obavezno!")]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal FullPriceWithTax { get; set; }

        [Required(ErrorMessage = "Ovo polje je obavezno!")]
        public int PhoneId { get; set; }
        public Phone Phone { get; set; }

        
    }
}
