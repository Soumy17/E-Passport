using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EPassport.Models
{
    [Table("applications", Schema = "Passport")]
    public class ApplicationForm
    {
        [Key]
        public int applicationId { get; set; }
		public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime dOB { get; set; }
        public string placeOfBirth { get; set; }
        public string maritalStatus { get; set; }
        public string pan { get; set; }
        public string employmentType
        { get; set; }
        public string applicantGender { get; set; }
        public string educationalQualification { get; set; }
        public string fatherName { get; set; }
        public string motherName { get; set; }
        public string houseNo { get; set; }
        public int streetNumber { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string district { get; set; }
        public int pincode { get; set; }
        public long telePhoneNumber { get; set; }
        public string applicantEMailId { get; set; }
        public string referanceName { get; set; }
        public string address { get; set; }
        public long refTelephoneNumber { get; set; }
    }
 }