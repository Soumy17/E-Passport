using EPassport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EPassport.Controllers
{
    public class AppointmentScheduleController : ApiController
    {
		[HttpGet, ActionName("GetAllAppointmentSchedules")]
		public List<AppointmentSchedule> GetAppointmentSchedules()
		{
			List<AppointmentSchedule> regList = null;
			try
			{
				EPassportDBDAL dbDal = new EPassportDBDAL();
				regList = dbDal.GetAppointmentSchedules();
			}
			catch (Exception e)
			{
				throw e;
			}
			return regList;
		}


		public AppointmentSchedule GetAppointmentScheduleById(int gId)
		{
			AppointmentSchedule grd = null;
			try
			{
				EPassportDBDAL dBDAL = new EPassportDBDAL();
				grd = dBDAL.GetAppointmentScheduleById(gId);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return grd;
		}


		public int PostAppointmentSchedule(int uid, [FromBody] AppointmentSchedule grd)
		{
			int result = 0;
			try
			{
				EPassportDBDAL dBDAL = new EPassportDBDAL();
				grd.applicationId = uid;
				result = dBDAL.UpdateAppointmentSchedule(grd);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return result;
		}

		public int PostAppointmentSchedule([FromBody] AppointmentSchedule grd)
		{
			int result = 0;
			try
			{
				EPassportDBDAL dBDAL = new EPassportDBDAL();
				result = dBDAL.AddAppointmentSchedule(grd);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return result;
		}

		[HttpDelete]
		public int DeleteAppointmentSchedule(int userid)
		{
			int result = 0;
			try
			{
				EPassportDBDAL dBDAL = new EPassportDBDAL();
				result = dBDAL.DeleteAppointmentScheduleById(userid);
			}
			catch (Exception e)
			{
				throw;
			}
			return result;
		}
	}
}
