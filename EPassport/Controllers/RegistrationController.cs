using EPassport.Models;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EPassport.Controllers
{
    public class RegistrationController : ApiController
    {
        [HttpGet, ActionName("GetAllRegistrations")]
        public List<UserRegistration> GetRegistrations()
        {
            List<UserRegistration> regList = null;
            try
            {
                EPassportDBDAL dbDal = new EPassportDBDAL();
                regList = dbDal.GetRegistrations();
            }
            catch (Exception e)
            {
                throw e;
            }
            return regList;
        }


        public UserRegistration GetUserById(int gId)
        {
            UserRegistration grd = null;
            try
            {
                EPassportDBDAL dBDAL = new EPassportDBDAL();
                grd = dBDAL.GetUserById(gId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return grd;
        }


        public int PostUser(int uid, [FromBody] UserRegistration grd)
        {
            int result = 0;
            try
            {
                EPassportDBDAL dBDAL = new EPassportDBDAL();
                grd.UserRegistration_Id = uid;
                result = dBDAL.UpdateUser(grd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public int PostUser([FromBody] UserRegistration grd)
        {
            int result = 0;
            try
            {
                EPassportDBDAL dBDAL = new EPassportDBDAL();
                result = dBDAL.AddUser(grd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        [HttpDelete]
        public int DeleteUser(int userid)
        {
            int result = 0;
            try
            {
                EPassportDBDAL dBDAL = new EPassportDBDAL();
                result = dBDAL.DeleteUserById(userid);
            }
            catch(Exception e)
            {
                throw;
            }
            return result;
        }
    }
}
