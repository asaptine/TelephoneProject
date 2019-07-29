using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Projekt.Models
{
    public class Country : BaseModel
    {

        [Required(ErrorMessage = "Ovo polje je obavezno i ne može sadržavati više od 100 znakova!")]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
