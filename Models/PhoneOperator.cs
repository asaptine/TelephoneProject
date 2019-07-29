using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Projekt.Models
{
    public class PhoneOperator : BaseModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ovo polje je obavezno i ne može sadržavati više od 10 znakova!")]
        [MaxLength(10)]
        public string Sim { get; set; }

        [Required(ErrorMessage = "Ovo polje je obavezno!")]
        public int OperatorId { get; set; }
        public Operator Operator { get; set; }


        [Required(ErrorMessage = "Ovo polje je obavezno!")]
        public int PhoneId { get; set; }
        public Phone Phone { get; set; }

    }
}
