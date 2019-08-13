using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Projekt.Models
{
    public class Location : BaseEntity
    {

        [Required(ErrorMessage = "Ovo polje je obavezno i ne može sadržavati više od 100 znakova!")]
        [MaxLength(100, ErrorMessage = "Max duljina je 100 znakova.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Ovo polje je obavezno!")]
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
