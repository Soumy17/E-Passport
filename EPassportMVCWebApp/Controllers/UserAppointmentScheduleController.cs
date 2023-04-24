using EPassportMVCWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EPassportMVCWebApp.Controllers
{
    public class UserAppointmentScheduleController : Controller
    {

        IList<UserAppointmentSchedule> userAppointmentSchedule = null;
        HttpClient client;
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult GetUserAppointmentScheduleDetails()
        {
            if (!ModelState.IsValid)
                return BadRequest("not a valid model");
            using (client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44309/api/");
                var responseTask = client.GetAsync("UserAppointmentSchedule");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<UserAppointmentSchedule[]>();
                    readTask.Wait();
                    userAppointmentSchedule = readTask.Result.ToList();
                }
                else
                {
                    userAppointmentSchedule = Enumerable.Empty<UserAppointmentSchedule>().ToList();
                    ModelState.AddModelError(string.Empty, "server error.please ");
                }
                return View(userAppointmentSchedule);

            }
        }



        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUserAppointmentScheduleDetails(UserAppointmentSchedule user)
        {
            int RecordsAdded = 0;
            // if (!ModelState.IsValid)
            // return BadRequest("Not a valid Model");

            using (client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44309/api/");
                //HTTP POST
                var postTask = client.PostAsJsonAsync<UserAppointmentSchedule>("UserAppointmentSchedule", user);
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
            return RedirectToAction("GetUserAppointmentScheduleDetails");
        }



        [HttpGet]
        public ActionResult GetUserAppointmentScheduleDetailById(int userid)
        {
            UserAppointmentSchedule user = null;
            using (client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44309/api/");
                //HTTP GET
                var responseTask = client.GetAsync("UserAppointmentSchedule?gId=" + userid);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<UserAppointmentSchedule>();
                    readTask.Wait();
                    user = readTask.Result;
                }
            }
            return View(user);
        }



        public ActionResult DeleteUserAppointmentScheduleDetails(int userid)
        {
            var RecordsModified = 0;
            using (client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44309/api/");
                var postTask = client.DeleteAsync("UserAppointmentSchedule/?userid=" + userid);
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
                    return View("DeleteUserAppointmentScheduleDetails");
                }
            }
            return RedirectToAction("GetUserAppointmentScheduleDetails");
        }





        [HttpGet]
        public ActionResult EditUserAppointmentScheduleDetails(int grdId)
        {
            UserAppointmentSchedule grd = null;
            //var RecordsModified = 0;
            using (client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44309/api/");
                // HTTP GET the grade by passing the grade Id
                var responseTask = client.GetAsync($"UserAppointmentSchedule/?gId={grdId}");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<UserAppointmentSchedule>();
                    readTask.Wait();
                    grd = readTask.Result;
                }
            }
            return View(grd);
        }

        [HttpPost]
        public ActionResult EditUserAppointmentScheduleDetails(UserAppointmentSchedule grd)
        {
            int RecordsModified = 0;
            using (client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44309/api/");
                // Http Get all the grades as an array of grade objects
                var postTask = client.PostAsJsonAsync("UserAppointmentSchedule/?uid=" + grd.applicationId, grd);
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
                    return View("EditUserAppointmentScheduleDetails", grd);
                }
            }
            return RedirectToAction("GetUserAppointmentScheduleDetails");
        }
    }
}
