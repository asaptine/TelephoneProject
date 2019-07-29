using System;

namespace Projekt.Models
{
    public class BaseModel
    {
        public int Id {get; set;}
        public DateTime CreatedAt {get; set;}

        public DateTime? UpdatedAt { get; set; }
    }
}