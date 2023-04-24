using EPassport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EPassport.Controllers
{
	public class UserAppointmentScheduleController : ApiController
	{

		public List<UserAppointmentSchedule> GetUserAppointmentScheduleDetails()
		{
			List<UserAppointmentSchedule> regList = null;
			try
			{
				EPassportDBDAL dbDal = new EPassportDBDAL();
				regList = dbDal.GetUserAppointmentScheduleDetails();
			}
			catch (Exception e)
			{
				throw e;
			}
			return regList;
		}

		public UserAppointmentSchedule GetUserAppointmentScheduleById(int gId)
		{
			UserAppointmentSchedule grd = null;
			try
			{
				EPassportDBDAL dBDAL = new EPassportDBDAL();
				grd = dBDAL.GetUserAppointmentScheduleById(gId);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return grd;
		}


		public int PostUserAppointmentSchedule(int uid, [FromBody] UserAppointmentSchedule grd)
		{
			int result = 0;
			try
			{
				EPassportDBDAL dBDAL = new EPassportDBDAL();
				grd.applicationId = uid;
				result = dBDAL.UpdateUserAppointmentSchedule(grd);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return result;
		}


		public int PostUserAppointmentSchedule([FromBody] UserAppointmentSchedule grd)
		{
			int result = 0;
			try
			{
				EPassportDBDAL dBDAL = new EPassportDBDAL();
				result = dBDAL.AddUserAppointmentSchedule(grd);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return result;
		}


		[HttpDelete]
		public int DeleteUserAppointmentSchedule(int userid)
		{
			int result = 0;
			try
			{
				EPassportDBDAL dBDAL = new EPassportDBDAL();
				result = dBDAL.DeleteUserAppointmentScheduleById(userid);
			}
			catch (Exception e)
			{
				throw;
			}
			return result;

		}
	}
}
