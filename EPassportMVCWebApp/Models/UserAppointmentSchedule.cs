using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPassportMVCWebApp.Models
{
    public class UserAppointmentSchedule
    {
		public int applicationId { get; set; }
		public int MonthId { get; set; }
        public DateTime date { get; set; }
        //  public int avaiableDays { get; set; }
        public DateTime timeSlots { get; set; }
        //public string monthName { get; set; }
    }
}