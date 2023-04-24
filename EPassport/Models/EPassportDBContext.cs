using EPassport.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


    namespace Epassport.Models
    {
        public class EpassportDBContext : DbContext

        {
        public EpassportDBContext() : base("name=EpassportConnectionString")
        {
            // Database.SetInitializer<EpassportDBContext>(new CreateDatabaseIfNotExists<EpassportDBContext>());
            // Database.SetInitializer<SchoolDBContext>(new DropCreateDatabaseIfModelChanges<EpassportDBContext>());
            Database.SetInitializer<EpassportDBContext>(new EpassportDBInitializer());
        }
       
        public DbSet<UserRegistration> UserRegistrations { get; set; }
        public DbSet<ApplicationForm> ApplicationForms { get; set; }
        public DbSet<OfficeDetails> OfficeDetails { get; set; }
        public DbSet<AppointmentSchedule> AppointmentSchedules { get; set; }
        //public IEnumerable<object> UserRegistration { get; internal set; }
         public DbSet<UserAppointmentSchedule> UserAppointmentSchedules { get; set; }

    }
    }
