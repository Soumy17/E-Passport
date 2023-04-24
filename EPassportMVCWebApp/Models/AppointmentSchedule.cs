using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EPassportMVCWebApp.Models
{
    public class AppointmentSchedule
    {
		public int applicationId { get; set; }
		public DateTime date { get; set; }
        public int avaiableDays { get; set; }
        public DateTime timeSlots { get; set; }
        public string monthName { get; set; }
    }
}