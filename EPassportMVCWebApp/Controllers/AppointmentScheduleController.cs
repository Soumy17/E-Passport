using EPassportMVCWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EPassportMVCWebApp.Controllers
{
    public class AppointmentScheduleController : Controller
    {
        IList<AppointmentSchedule> appointmentSchedule = null;
        HttpClient client;
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult GetAppointmentScheduleDetails()
        {
            if (!ModelState.IsValid)
                return BadRequest("not a valid model");
            using (client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44309/api/");
                var responseTask = client.GetAsync("AppointmentSchedule");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<AppointmentSchedule[]>();
                    readTask.Wait();
                    appointmentSchedule = readTask.Result.ToList();
                }
                else
                {
                    appointmentSchedule = Enumerable.Empty<AppointmentSchedule>().ToList();
                    ModelState.AddModelError(string.Empty, "server error.please ");
                }
                return View(appointmentSchedule);

            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAppointmentScheduleDetails(AppointmentSchedule user)
        {
            int RecordsAdded = 0;
            // if (!ModelState.IsValid)
            // return BadRequest("Not a valid Model");

            using (client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44309/api/");
                //HTTP POST
                var postTask = client.PostAsJsonAsync<AppointmentSchedule>("AppointmentSchedule", user);
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
            return RedirectToAction("GetAppointmentScheduleDetails");
        }



        [HttpGet]
        public ActionResult GetAppointmentScheduleDetailsById(int userid)
        {
            AppointmentSchedule user = null;
            using (client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44309/api/");
                //HTTP GET
                var responseTask = client.GetAsync("AppointmentSchedule?gId=" + userid);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<AppointmentSchedule>();
                    readTask.Wait();
                    user = readTask.Result;
                }
            }
            return View(user);
        }



        public ActionResult DeleteAppointmentScheduleDetails(int userid)
        {
            var RecordsModified = 0;
            using (client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44309/api/");
                var postTask = client.DeleteAsync("AppointmentSchedule/?userid=" + userid);
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
                    return View("DeleteOfficeDetails");
                }
            }
            return RedirectToAction("GetAppointmentScheduleDetails");
        }





        [HttpGet]
        public ActionResult EditAppointmentScheduleDetails(int grdId)
        {
            AppointmentSchedule grd = null;
            //var RecordsModified = 0;
            using (client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44309/api/");
                // HTTP GET the grade by passing the grade Id
                var responseTask = client.GetAsync($"AppointmentSchedule/?gId={grdId}");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<AppointmentSchedule>();
                    readTask.Wait();
                    grd = readTask.Result;
                }
            }
            return View(grd);
        }

        [HttpPost]
        public ActionResult EditAppointmentScheduleDetails(AppointmentSchedule grd)
        {
            int RecordsModified = 0;
            using (client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44309/api/");
                // Http Get all the grades as an array of grade objects
                var postTask = client.PostAsJsonAsync("AppointmentSchedule/?uid=" + grd.applicationId, grd);
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
                    return View("EditOfficeDetails", grd);
                }
            }
            return RedirectToAction("GetAppointmentScheduleDetails");
        }
    }
}
