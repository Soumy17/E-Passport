using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EPassportMVCWebApp.Models
{
    public class OfficeDetails
    {
        public int officeid { get; set; }
       public string officeName { get; set; }
       public string Address { get; set; }
       public long phonenumber { get; set; }
    }
}