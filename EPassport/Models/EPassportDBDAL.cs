using Epassport.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace EPassport.Models
{
    public class EPassportDBDAL
    {

        public EpassportDBContext passportCtx;
        public EPassportDBDAL()
        {
            passportCtx = new EpassportDBContext();
        }
        public List<UserRegistration> GetRegistrations()
        {
            List<UserRegistration> regList = passportCtx.UserRegistrations.ToList();
            return regList;
        }

        public UserRegistration GetUserById(int gId)
        {
            UserRegistration grd = null;
            try
            {
                grd = passportCtx.UserRegistrations
                                          .Where(g => g.UserRegistration_Id == gId)
                                          .Single();
            }
            catch { throw; }
            return grd;
        }


        public int UpdateUser(UserRegistration std)
        {
            UserRegistration S1 = null;
            int recModified = 0;
            try
            {
                S1 = new UserRegistration();
                S1 = passportCtx.UserRegistrations
                                       .Where(s => s.UserRegistration_Id == std.UserRegistration_Id)
                                       .Single<UserRegistration>();
                if (S1 != null)
                {
                    S1.firstName = std.firstName;
                    S1.lastName = std.lastName;
                    S1.dOB = std.dOB;
                    S1.password = std.password;
                    S1.gender = std.gender;
                    S1.phoneNumber = std.phoneNumber;
                    passportCtx.Entry(S1).State = System.Data.Entity.EntityState.Modified;
                    recModified = passportCtx.SaveChanges();
                }
            }
            catch { throw; }
            return recModified;
        }

        public int AddUser(UserRegistration GRD)
        {
            int rowchanges = 0;
            try
            {
                passportCtx.UserRegistrations.Add(GRD);
                rowchanges = passportCtx.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
            return rowchanges;
        }

        public int DeleteUserById(int id)
        {
            UserRegistration S1 = null;
            int recDeleted = 0;
            try
            {
                S1 = new UserRegistration();
                S1 = passportCtx.UserRegistrations
                                       .Where(s => s.UserRegistration_Id == id)
                                       .FirstOrDefault<UserRegistration>();
                if (S1 != null)
                {
                    passportCtx.Entry(S1).State = System.Data.Entity.EntityState.Deleted;
                    recDeleted = passportCtx.SaveChanges();
                }
            }
            catch { throw; }
            return recDeleted;
        }


		//====================================================================  Office Details ========================================================

	
		public List<OfficeDetails> GetOfficeDetails()
	
		{
			List<OfficeDetails> regList = passportCtx.OfficeDetails.ToList();
			return regList;
		}




		public OfficeDetails GetOfficeById(int gId)
		{
			OfficeDetails grd = null;
			try
			{
				grd = passportCtx.OfficeDetails
										  .Where(g => g.officeid == gId)
										  .Single();
			}
			catch { throw; }
			return grd;
		}


		public int UpdateOffice(OfficeDetails std)
		{
			OfficeDetails S1 = null;
			int recModified = 0;
			try
			{
				S1 = new OfficeDetails();
				S1 = passportCtx.OfficeDetails
									   .Where(s => s.officeid == std.officeid)
									   .Single<OfficeDetails>();
				if (S1 != null)
				{
					S1.officeName = std.officeName;
					S1.Address = std.Address;
					S1.phonenumber = std.phonenumber;
					passportCtx.Entry(S1).State = System.Data.Entity.EntityState.Modified;
					recModified = passportCtx.SaveChanges();
				}
			}
			catch { throw; }
			return recModified;
		}
		public int AddOffice(OfficeDetails GRD)
		{
			int rowchanges = 0;
			try
			{
				passportCtx.OfficeDetails.Add(GRD);
				rowchanges = passportCtx.SaveChanges();
			}
			catch (Exception e)
			{
				throw e;
			}
			return rowchanges;
		}


		public int DeleteOfficeById(int id)
		{
			OfficeDetails S1 = null;
			int recDeleted = 0;
			try
			{
				S1 = new OfficeDetails();
				S1 = passportCtx.OfficeDetails
									   .Where(s => s.officeid == id)
									   .FirstOrDefault<OfficeDetails>();
				if (S1 != null)
				{
					passportCtx.Entry(S1).State = System.Data.Entity.EntityState.Deleted;
					recDeleted = passportCtx.SaveChanges();
				}
			}
			catch { throw; }
			return recDeleted;
		}






		//====================================================================  Application Form  ========================================================



		public List<ApplicationForm> GetApplicationForms()

		{
			List<ApplicationForm> regList = passportCtx.ApplicationForms.ToList();
			return regList;
		}




		public ApplicationForm GetApplicationFormById(int gId)
		{
			ApplicationForm grd = null;
			try
			{
				grd = passportCtx.ApplicationForms
										  .Where(g => g.applicationId == gId)
										  .Single();
			}
			catch { throw; }
			return grd;
		}


		public int UpdateApplicationForm(ApplicationForm std)
		{
			ApplicationForm S1 = null;
			int recModified = 0;
			try
			{
				S1 = new ApplicationForm();
				S1 = passportCtx.ApplicationForms
									   .Where(s => s.applicationId == std.applicationId)
									   .Single<ApplicationForm>();
				if (S1 != null)
				{
					S1.firstName = std.firstName;
					S1.lastName = std.lastName;
					S1.dOB = std.dOB;
					S1.placeOfBirth = std.placeOfBirth;
					S1.maritalStatus = std.placeOfBirth;
					S1.pan = std.pan;
					S1.employmentType = std.employmentType;
					S1.applicantGender = std.applicantGender;
					S1.educationalQualification = std.educationalQualification;
					S1.fatherName = std.fatherName;
					S1.motherName = std.motherName;
					S1.houseNo = std.houseNo;
					S1.streetNumber = std.streetNumber;
					S1.city = std.city;
					S1.state = std.state;
					S1.district = std.district;
					S1.pincode = std.pincode;
					S1.telePhoneNumber = std.telePhoneNumber;
					S1.applicantEMailId = std.applicantEMailId;
					S1.referanceName = std.referanceName;
					S1.address = std.address;
					S1.refTelephoneNumber = std.refTelephoneNumber;
					passportCtx.Entry(S1).State = System.Data.Entity.EntityState.Modified;
					recModified = passportCtx.SaveChanges();
				}
			}
			catch { throw; }
			return recModified;
		}
		public int AddApplicationForm(ApplicationForm GRD)
		{
			int rowchanges = 0;
			try
			{
				passportCtx.ApplicationForms.Add(GRD);
				rowchanges = passportCtx.SaveChanges();
			}
			catch (Exception e)
			{
				throw e;
			}
			return rowchanges;
		}


		public int DeleteApplicationFormById(int id)
		{
			ApplicationForm S1 = null;
			int recDeleted = 0;
			try
			{
				S1 = new ApplicationForm();
				S1 = passportCtx.ApplicationForms
									   .Where(s => s.applicationId == id)
									   .FirstOrDefault<ApplicationForm>();
				if (S1 != null)
				{
					passportCtx.Entry(S1).State = System.Data.Entity.EntityState.Deleted;
					recDeleted = passportCtx.SaveChanges();
				}
			}
			catch { throw; }
			return recDeleted;
		}


		//====================================================================  Office Details ========================================================


		public List<AppointmentSchedule> GetAppointmentSchedules()

		{
			List<AppointmentSchedule> regList = passportCtx.AppointmentSchedules.ToList();
			return regList;
		}




		public AppointmentSchedule GetAppointmentScheduleById(int gId)
		{
			AppointmentSchedule grd = null;
			try
			{
				grd = passportCtx.AppointmentSchedules
										  .Where(g => g.applicationId == gId)
										  .Single();
			}
			catch { throw; }
			return grd;
		}


		public int UpdateAppointmentSchedule(AppointmentSchedule std)
		{
			AppointmentSchedule S1 = null;
			int recModified = 0;
			try
			{
				S1 = new AppointmentSchedule();
				S1 = passportCtx.AppointmentSchedules
									   .Where(s => s.applicationId == std.applicationId)
									   .Single<AppointmentSchedule>();
				if (S1 != null)
				{
					S1.date = std.date;
					S1.avaiableDays = std.avaiableDays;
					S1.timeSlots = std.timeSlots;
					S1.monthName = std.monthName;
					passportCtx.Entry(S1).State = System.Data.Entity.EntityState.Modified;
					recModified = passportCtx.SaveChanges();
				}
			}
			catch { throw; }
			return recModified;
		}
		public int AddAppointmentSchedule(AppointmentSchedule GRD)
		{
			int rowchanges = 0;
			try
			{
				passportCtx.AppointmentSchedules.Add(GRD);
				rowchanges = passportCtx.SaveChanges();
			}
			catch (Exception e)
			{
				throw e;
			}
			return rowchanges;
		}


		public int DeleteAppointmentScheduleById(int id)
		{
			AppointmentSchedule S1 = null;
			int recDeleted = 0;
			try
			{
				S1 = new AppointmentSchedule();
				S1 = passportCtx.AppointmentSchedules
									   .Where(s => s.applicationId == id)
									   .FirstOrDefault<AppointmentSchedule>();
				if (S1 != null)
				{
					passportCtx.Entry(S1).State = System.Data.Entity.EntityState.Deleted;
					recDeleted = passportCtx.SaveChanges();
				}
			}
			catch { throw; }
			return recDeleted;
		}




		//====================================================================  UserAppointmentSchedule ========================================================


		public List<UserAppointmentSchedule> GetUserAppointmentScheduleDetails()

		{
			List<UserAppointmentSchedule> regList = passportCtx.UserAppointmentSchedules.ToList();
			return regList;
		}




		public UserAppointmentSchedule GetUserAppointmentScheduleById(int gId)
		{
			UserAppointmentSchedule grd = null;
			try
			{
				grd = passportCtx.UserAppointmentSchedules
										  .Where(g => g.applicationId == gId)
										  .Single();
			}
			catch { throw; }
			return grd;
		}



		public int UpdateUserAppointmentSchedule(UserAppointmentSchedule std)
		{
			UserAppointmentSchedule S1 = null;
			int recModified = 0;
			try
			{
				S1 = new UserAppointmentSchedule();
				S1 = passportCtx.UserAppointmentSchedules
									   .Where(s => s.applicationId == std.applicationId)
									   .Single<UserAppointmentSchedule>();
				if (S1 != null)
				{
					S1.MonthId = std.MonthId;
					S1.date = std.date;
					S1.avaiableDays = std.avaiableDays;
					S1.timeSlots = std.timeSlots;
					S1.monthName = std.monthName;
					passportCtx.Entry(S1).State = System.Data.Entity.EntityState.Modified;
					recModified = passportCtx.SaveChanges();
				}
			}
			catch { throw; }
			return recModified;
		}


		public int AddUserAppointmentSchedule(UserAppointmentSchedule GRD)
		{
			int rowchanges = 0;
			try
			{
				passportCtx.UserAppointmentSchedules.Add(GRD);
				rowchanges = passportCtx.SaveChanges();
			}
			catch (Exception e)
			{
				throw e;
			}
			return rowchanges;
		}



		public int DeleteUserAppointmentScheduleById(int id)
		{
			UserAppointmentSchedule S1 = null;
			int recDeleted = 0;
			try
			{
				S1 = new UserAppointmentSchedule();
				S1 = passportCtx.UserAppointmentSchedules
									   .Where(s => s.applicationId == id)
									   .FirstOrDefault<UserAppointmentSchedule>();
				if (S1 != null)
				{
					passportCtx.Entry(S1).State = System.Data.Entity.EntityState.Deleted;
					recDeleted = passportCtx.SaveChanges();
				}
			}
			catch { throw; }
			return recDeleted;
		}





	}
}