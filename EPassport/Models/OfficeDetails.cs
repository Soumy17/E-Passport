using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EPassport.Models
{
    [Table("officeDetails", Schema = "Passport")]
    public class OfficeDetails
    {
        [Key]
        public int officeid { get; set; }
       public string officeName { get; set; }
       public string Address { get; set; }
       public long phonenumber { get; set; }
    }
}