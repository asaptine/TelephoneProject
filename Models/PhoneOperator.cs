using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Projekt.Models
{
    public class PhoneOperator : BaseEntity
    {

        [Required(ErrorMessage = "Ovo polje je obavezno i ne može sadržavati više od 10 znakova!")]
        [MaxLength(10, ErrorMessage = "Max duljina je 10 znakova.")]
        public string Sim { get; set; }

        [Required(ErrorMessage = "Ovo polje je obavezno!")]
        public int AppOperatorId { get; set; }
        public AppOperator AppOperator { get; set; }


        [Required(ErrorMessage = "Ovo polje je obavezno!")]
        public int PhoneId { get; set; }
        public Phone Phone { get; set; }

    }
}
