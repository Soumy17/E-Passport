using EPassportMVCWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EPassportMVCWebApp.Controllers
{
    public class ApplicationFormController : Controller
    {

        IList<ApplicationForm> applicationForm = null;
        HttpClient client;
        public IActionResult Index()
        {
            return View();
        }
       

        public ActionResult GetApplicationFormDetails()
        {
            if (!ModelState.IsValid)
                return BadRequest("not a valid model");
            using (client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44309/api/");
                var responseTask = client.GetAsync("ApplicationForm");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ApplicationForm[]>();
                    readTask.Wait();
                    applicationForm = readTask.Result.ToList();
                }
                else
                {
                    applicationForm = Enumerable.Empty<ApplicationForm>().ToList();
                    ModelState.AddModelError(string.Empty, "server error.please ");
                }
                return View(applicationForm);

            }
        }



        public ActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public ActionResult AddApplicationFormDetails(ApplicationForm user)
        {
            int RecordsAdded = 0;
            // if (!ModelState.IsValid)
            // return BadRequest("Not a valid Model");

            using (client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44309/api/");
                //HTTP POST
                var postTask = client.PostAsJsonAsync<ApplicationForm>("ApplicationForm", user);
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
            return RedirectToAction("FormFilledSuccessfully");
        }



        [HttpGet]
        public ActionResult GetApplicationFormById(int userid)
        {
            ApplicationForm user = null;
            using (client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44309/api/");
                //HTTP GET
                var responseTask = client.GetAsync("ApplicationForm?gId=" + userid);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ApplicationForm>();
                    readTask.Wait();
                    user = readTask.Result;
                }
            }
            return View(user);
        }



        public ActionResult DeleteApplicationFormDetails(int userid)
        {
            var RecordsModified = 0;
            using (client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44309/api/");
                var postTask = client.DeleteAsync("ApplicationForm/?userid=" + userid);
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
                    return View("DeleteApplicationFormDetails");
                }
            }
            return RedirectToAction("GetApplicationFormDetails");
        }





        [HttpGet]
        public ActionResult EditApplicationFormDetails(int grdId)
        {
            ApplicationForm grd = null;
            //var RecordsModified = 0;
            using (client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44309/api/");
                // HTTP GET the grade by passing the grade Id
                var responseTask = client.GetAsync($"ApplicationForm/?gId={grdId}");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ApplicationForm>();
                    readTask.Wait();
                    grd = readTask.Result;
                }
            }
            return View(grd);
        }

        [HttpPost]
        public ActionResult EditApplicationFormDetails(ApplicationForm grd)
        {
            int RecordsModified = 0;
            using (client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44309/api/");
                // Http Get all the grades as an array of grade objects
                var postTask = client.PostAsJsonAsync("ApplicationForm/?uid=" + grd.applicationId, grd);
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
                    return View("EditApplicationFormDetails", grd);
                }
            }
            return RedirectToAction("GetApplicationFormDetails");
        }
    }
}
