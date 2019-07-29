using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Projekt.Models
{
    public class Operator : BaseModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ovo polje je obavezno i ne može sadržavati više od 20 znakova!")]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Ovo polje je obavezno i ne može sadržavati više od 20 znakova!")]
        [MaxLength(20)]
        public int DialingNumber { get; set; }

        
        [Required(ErrorMessage = "Ovo polje je obavezno!")]
        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}
