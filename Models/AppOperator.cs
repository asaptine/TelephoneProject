using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Projekt.Models
{
    public class AppOperator : BaseEntity
    {

        [Required(ErrorMessage = "Ovo polje je obavezno i ne može sadržavati više od 20 znakova!")]
        [MaxLength(20, ErrorMessage = "Max duljina je 20 znakova.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Ovo polje je obavezno i ne može sadržavati više od 20 znakova!")]
        [MaxLength(20, ErrorMessage = "Max duljina je 20 znakova.")]
        public int DialingNumber { get; set; }

        
        [Required(ErrorMessage = "Ovo polje je obavezno!")]
        public int LocationId { get; set; }
        public Location Location { get; set; }

        public ICollection<PhoneOperator> PhoneOperators {get ; set;}
    }
}
