using EPassport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EPassport.Controllers
{
    public class ApplicationFormController : ApiController
    {

		[HttpGet, ActionName("GetAllApplicationForms")]
		public List<ApplicationForm> GetApplicationForms()
		{
			List<ApplicationForm> regList = null;
			try
			{
				EPassportDBDAL dbDal = new EPassportDBDAL();
				regList = dbDal.GetApplicationForms();
			}
			catch (Exception e)
			{
				throw e;
			}
			return regList;
		}


		public ApplicationForm GetApplicationFormById(int gId)
		{
			ApplicationForm grd = null;
			try
			{
				EPassportDBDAL dBDAL = new EPassportDBDAL();
				grd = dBDAL.GetApplicationFormById(gId);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return grd;
		}


		public int PostApplicationForm(int uid, [FromBody] ApplicationForm grd)
		{
			int result = 0;
			try
			{
				EPassportDBDAL dBDAL = new EPassportDBDAL();
				grd.applicationId = uid;
				result = dBDAL.UpdateApplicationForm(grd);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return result;
		}

		public int PostApplicationForm([FromBody] ApplicationForm grd)
		{
			int result = 0;
			try
			{
				EPassportDBDAL dBDAL = new EPassportDBDAL();
				result = dBDAL.AddApplicationForm(grd);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return result;
		}

		[HttpDelete]
		public int DeleteApplicationForm(int userid)
		{
			int result = 0;
			try
			{
				EPassportDBDAL dBDAL = new EPassportDBDAL();
				result = dBDAL.DeleteApplicationFormById(userid);
			}
			catch (Exception e)
			{
				throw;
			}
			return result;
		}
	}
}
