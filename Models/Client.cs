using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Projekt.Models
{
    public class Client : BaseEntity

    {

        [Required(ErrorMessage = "Ovo polje je obavezno i ne može sadržavati više od 20 znakova!")]
        [MaxLength(20, ErrorMessage = "Max duljina je 20 znakova.")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Ovo polje je obavezno i ne može sadržavati više od 20 znakova!")]
        [MaxLength(10, ErrorMessage = "Max duljina je 20 znakova.")]
        
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
                                                                                                                                                                                                                                                                                                                                                                                                                            	 
        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}
