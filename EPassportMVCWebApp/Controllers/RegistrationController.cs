using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net.Http;
using System;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using EPassportMVCWebApp.Models;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
//Forlogin
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace EpassportMVCWebApp.Controllers
{

    public class RegistrationController : Controller
    {
        IList<UserRegistration> userRegistrations = null;
        HttpClient client;
        private ILoginService myLoginService;


        public RegistrationController(ILoginService _LoginService)
        {
            myLoginService = _LoginService;
        }
        public IActionResult Index()
        {
            return View();
        }
        //[Authorize]
        public ActionResult GetRegistrations()
        {
            if (!ModelState.IsValid)
                return BadRequest("not a valid model");
            using (client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44309/api/");
                var responseTask = client.GetAsync("Registration");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<UserRegistration[]>();
                    readTask.Wait();
                    userRegistrations = readTask.Result.ToList();
                }
                else
                {
                    userRegistrations = Enumerable.Empty<UserRegistration>().ToList();
                    ModelState.AddModelError(string.Empty, "server error.please ");
                }
                return View(userRegistrations);

            }
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddUser(UserRegistration user)
        {
            int RecordsAdded = 0;
            // if (!ModelState.IsValid)
            // return BadRequest("Not a valid Model");

            using (client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44309/api/");
                //HTTP POST
                var postTask = client.PostAsJsonAsync<UserRegistration>("Registration", user);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<int>();
                    readTask.Wait();
                    RecordsAdded = readTask.Result;
                }
                else
                {
                    return View("Create");
                }
            }
            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult GetUserDetailById(int userid)
        {
            UserRegistration user = null;
            using (client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44309/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Registration?gId=" + userid);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<UserRegistration>();
                    readTask.Wait();
                    user = readTask.Result;
                }
            }
            return View(user);
        }


        public ActionResult DeleteUser(int userid)
        {
            var RecordsModified = 0;
            using (client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44309/api/");
                var postTask = client.DeleteAsync("Registration/?userid=" + userid);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<int>();
                    readTask.Wait();
                    RecordsModified = readTask.Result;
                }
                else
                {
                    return View("DeleteUser");
                }
            }
            return RedirectToAction("GetRegistrations");
        }

        [HttpGet]
        public ActionResult EditUser(int grdId)
        {
            UserRegistration grd = null;
            //var RecordsModified = 0;
            using (client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44309/api/");
                // HTTP GET the grade by passing the grade Id
                var responseTask = client.GetAsync($"Registration/?gId={grdId}");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<UserRegistration>();
                    readTask.Wait();
                    grd = readTask.Result;
                }
            }
            return View(grd);
        }

        [HttpPost]
        public ActionResult EditUser(UserRegistration grd)
        {
            int RecordsModified = 0;
            using (client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44309/api/");
                // Http Get all the grades as an array of grade objects
                var postTask = client.PostAsJsonAsync("Registration/?uid=" + grd.UserRegistration_Id, grd);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<int>();
                    readTask.Wait();
                    RecordsModified = readTask.Result;
                }
                else
                {
                    return View("EditUser", grd);
                }
            }
            return RedirectToAction("GetRegistrations");
        }

        [HttpGet]
        public ActionResult Login(string ReturnUrl = "/")
        {
            LoginModel objLoginModel = new LoginModel();
            objLoginModel.ReturnUrl = ReturnUrl;
            return View(objLoginModel);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel objLoginModel)
        {
            List<Claim> myClaims = null;
            try
            {
                myClaims = myLoginService.LogMeIn(objLoginModel);
                if (myClaims != null)
                {
                    var identity = new ClaimsIdentity(myClaims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        principal, new AuthenticationProperties()
                        {
                            IsPersistent = objLoginModel.RememberLogin
                        });
                    string role = objLoginModel.Role;
                    if(role == "Admin")
                    {
                        return RedirectToAction("AdminDashboard");
                    }
                    else if(role =="User")
                    {
                        //return RedirectToAction();
                        return RedirectToAction("UserDashboard");
                    }
                }
                else
                {
                    ViewBag.Message = "Invalid Credential";
                    return View(objLoginModel);
                }

            }
            catch (Exception e)
            {
                throw;
            }
            return View(objLoginModel);
        }


        public ActionResult AdminDashboard()
        {
            return View();
        }

        public ActionResult UserDashboard()
        {
            return View();
        }

        public ActionResult ApplicationSuccess()
        {
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            //SignOutAsync is extension method for SignOut
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            //Redirect to home page
            return LocalRedirect("/");
        }


    }
}