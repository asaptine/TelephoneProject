using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Projekt.Models
{
    public class Phone : BaseEntity
    {

        [DataType(DataType.Date)]
        public DateTime RegistrationDate { get; set; }

        [Required(ErrorMessage = "Ovo polje je obavezno!")]
        public int ClientId { get; set; }
        public Client Client { get; set; }

        public ICollection<PhoneOperator> PhoneOperators {get ; set;}
    }
}
