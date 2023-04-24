using EPassport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EPassport.Controllers
{
    public class OfficeDetailsController : ApiController
    {
		public List<OfficeDetails> GetOfficeDetails()
		{
			List<OfficeDetails> regList = null;
			try
			{
				EPassportDBDAL dbDal = new EPassportDBDAL();
				regList = dbDal.GetOfficeDetails();
			}
			catch (Exception e)
			{
				throw e;
			}
			return regList;
		}

		public OfficeDetails GetOfficeDetailsById(int gId)
		{
			OfficeDetails grd = null;
			try
			{
				EPassportDBDAL dBDAL = new EPassportDBDAL();
				grd = dBDAL.GetOfficeById(gId);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return grd;
		}


		public int PostOfficeDetails(int uid, [FromBody] OfficeDetails grd)
		{
			int result = 0;
			try
			{
				EPassportDBDAL dBDAL = new EPassportDBDAL();
				grd.officeid = uid;
				result = dBDAL.UpdateOffice(grd);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return result;
		}


		public int PostOfficeDetails([FromBody] OfficeDetails grd)
		{
			int result = 0;
			try
			{
				EPassportDBDAL dBDAL = new EPassportDBDAL();
				result = dBDAL.AddOffice(grd);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return result;
		}


		[HttpDelete]
		public int DeleteOffice(int userid)
		{
			int result = 0;
			try
			{
				EPassportDBDAL dBDAL = new EPassportDBDAL();
				result = dBDAL.DeleteOfficeById(userid);
			}
			catch (Exception e)
			{
				throw;
			}
			return result;
		}
	}
}
