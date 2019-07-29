using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Projekt.Models
{
    public class Client : BaseModel

    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ovo polje je obavezno i ne može sadržavati više od 20 znakova!")]
        [MaxLength(20)]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Ovo polje je obavezno i ne može sadržavati više od 20 znakova!")]
        [MaxLength(20)]
        public string FirstName { get; set; }

        public string FullName
        {
            get { return LastName + ", " + FirstName; }
        }


        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Ovo polje je obavezno!")]
        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}
