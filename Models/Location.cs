using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Projekt.Models
{
    public class Location : BaseModel
    {

        [Required(ErrorMessage = "Ovo polje je obavezno i ne može sadržavati više od 100 znakova!")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Ovo polje je obavezno!")]
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
