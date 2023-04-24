using EPassport.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;


       namespace Epassport.Models
    {
        public class EpassportDBInitializer : DropCreateDatabaseAlways<EpassportDBContext>
        {
           protected override void Seed(EpassportDBContext context)
           {
             var registrations = new List<UserRegistration>
              {
              new UserRegistration{ firstName="vaibhav",lastName="Thakre",dOB=DateTime.Parse("2000/06/31"),gender="male",eMailId="vaibhavthakre159@gmail.com",password="vaibhav@123",phoneNumber =1324456789,UserType="Admin",UserID ="rytwegfrdiuew2q817"},
              new UserRegistration{ firstName="sai",lastName="Divya",dOB=DateTime.Parse("2000/01/28"),gender="Female",eMailId="goaklghghfewu8@gmail.com",password="ytghmewuhji@43",phoneNumber =1324457654,UserType="User",UserID ="rytwegfrdiu8t62q817"},
              new UserRegistration { firstName ="Soumy",lastName ="Mishra",dOB = DateTime.Parse("2000/01/17"),gender ="Male",eMailId ="soumy@gmail.com",password="Soumy@123",phoneNumber = 456321457,UserType ="User",UserID="A"},
               new  UserRegistration {firstName ="Chandu",lastName ="Magadi",dOB = DateTime.Parse("1996/01/17"),gender ="Male",eMailId ="chandu@gmail.com",password="Chandu@123",phoneNumber =1234567890,UserType ="User",UserID="B"}
             };
              registrations.ForEach(g => context.UserRegistrations.Add(g));
                context.SaveChanges();

            //--------------------------------------------------

            var applicationForms = new List<ApplicationForm>
              {
     
                 new ApplicationForm{ firstName="vaibhav",lastName="thakre",dOB=DateTime.Parse("2000/05/30"),
                  placeOfBirth ="Mumbai",maritalStatus="unmarried",pan = "Evm2222",
                 employmentType ="GovServent", applicantGender="Female",educationalQualification = "BA",
                  fatherName = "Ramesh",motherName ="Yashoda",houseNo ="a",streetNumber =3,city ="Mumbai",
                  state="Maharashtra",district="Mumbai",pincode =43433,telePhoneNumber=07554544,
                  applicantEMailId ="chand@gmail.com",referanceName ="Chandrakant",address ="Vasant Nagar mumbai",
                  refTelephoneNumber = 789654123}

               };
            applicationForms.ForEach(g => context.ApplicationForms.Add(g));
            context.SaveChanges();

            //--------------------------------------------------
            var appointmentSchedule = new List<AppointmentSchedule>
              {
              new AppointmentSchedule { date=DateTime.Parse("2023/03/07"),avaiableDays=10,timeSlots=DateTime.Parse("2023/03/17"),monthName="February"},
              new AppointmentSchedule { date=DateTime.Parse("2022/04/10"),avaiableDays=15,timeSlots=DateTime.Parse("2022/04/17"),monthName="April"}
            };
            appointmentSchedule.ForEach(g => context.AppointmentSchedules.Add(g));
            context.SaveChanges();



            //---------------------------------------------------

            var officeDetails = new List<OfficeDetails>
            {
              new OfficeDetails { officeid = 1,officeName="Thane" ,Address="Mumbai",phonenumber=784554245}       
            };
            officeDetails.ForEach(g => context.OfficeDetails.Add(g));
            context.SaveChanges();

			//--------------------------------------------------
			var userappointmentSchedule = new List<UserAppointmentSchedule>
			  {
			  new UserAppointmentSchedule { MonthId=3,date=DateTime.Parse("2023/03/07"),avaiableDays = 10,timeSlots=DateTime.Parse("2023/03/17"),monthName="March"},
			  new UserAppointmentSchedule { MonthId=4,date=DateTime.Parse("2023/04/09"),avaiableDays = 10,timeSlots=DateTime.Parse("2023/04/14"),monthName="April"},
			  new UserAppointmentSchedule { MonthId=5,date=DateTime.Parse("2023/05/07"),avaiableDays = 10,timeSlots=DateTime.Parse("2023/05/17"),monthName="May"},
			 
			};
			userappointmentSchedule.ForEach(g => context.UserAppointmentSchedules.Add(g));
			context.SaveChanges();





		}
	}
    }




