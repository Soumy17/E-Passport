using EPassportMVCWebApp.Models;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;
using RequiredAttribute = Microsoft.Build.Framework.RequiredAttribute;

namespace EPassportMVCWebApp.Models
{
    public interface ILoginService
    {
        List<Claim> LogMeIn(LoginModel objLoginModel);
        void LogMeOut();
    }

    public class LoginService : ILoginService
    {
        private IConfiguration _Configuration;

        public LoginService(IConfiguration Config)
        {
            _Configuration = Config;
        }

        public List<Claim> LogMeIn(LoginModel objLoginModel)
        {

            SqlConnection con = null;
            SqlCommand cmd = null;
            List<Claim> claims = null;
            try
            {
                string SqlCon = this._Configuration.GetConnectionString("EpassportConnectionString");
                con = new SqlConnection(SqlCon);
                string SqlQuery = "select firstName,eMailId,password,UserType from Passport.registrations " + "Where eMailId = @Email and password = @Password";
                con.Open();
                cmd = new SqlCommand(SqlQuery, con);
                cmd.Parameters.AddWithValue("@Email", objLoginModel.UserName);
                cmd.Parameters.AddWithValue("@Password", objLoginModel.Password);
                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.Read())
                {
                    claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name,objLoginModel.UserName),
                        new Claim(ClaimTypes.Role,sdr["UserType"].ToString()),
                        new Claim("FavouriteDrink","Tea")
                    };
                    objLoginModel.Role = sdr["UserType"].ToString();

                }

            }catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
            return claims;
        }
       
        public void LogMeOut()
        {
            throw new NotImplementedException();
        }


    }
    public class LoginModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberLogin { get; set; }
        public string ReturnUrl { get; set; }
        public string Role { get; set; }
    }

    
}




/*    public class LoginModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberLogin { get; set; }
        public string ReturnUrl { get; set; }
    }

    public class UserModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}*/
