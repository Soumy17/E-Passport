using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EPassport.Models
{
[Table("registrations", Schema = "Passport")]

    public class UserRegistration
    {
        [Key]
        public int UserRegistration_Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime dOB { get; set; }
        public string gender { get; set; }
        public string eMailId { get; set; }
        public string password { get; set; }
        public int phoneNumber { get; set; }
        public String UserType { get; set; }
        public String UserID { get; set; }
    }
  }