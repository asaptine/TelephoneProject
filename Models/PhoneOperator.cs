using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Projekt.Models
{
    public class PhoneOperator : BaseEntity
    {

        
        public string Sim { get; set; }

        public int AppOperatorId { get; set; }
        public AppOperator AppOperator { get; set; }


        public int PhoneId { get; set; }
        public Phone Phone { get; set; }

    }
}
