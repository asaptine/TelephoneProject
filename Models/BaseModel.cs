using System;


namespace Projekt.Models
{
    public class BaseModel
    {

        public DateTime CreatedAt {get; set;}

        public DateTime? UpdatedAt { get; set; }

        public bool IsDeleted {get; set;} = false;
    }
}