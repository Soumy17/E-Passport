using EPassportMVCWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EPassportMVCWebApp.Controllers
{
   // [Authorize]
    public class OfficeDetailsController : Controller
    {
		IList<OfficeDetails> officeDetails = null;
		HttpClient client;
		public IActionResult Index()
        {
            return View();
        }

		public ActionResult GetOfficeDetails()
		{
			if (!ModelState.IsValid)
				return BadRequest("not a valid model");
			using (client = new HttpClient())
			{
				client.BaseAddress = new Uri("https://localhost:44309/api/");
				var responseTask = client.GetAsync("OfficeDetails");
				responseTask.Wait();
				var result = responseTask.Result;
				if (result.IsSuccessStatusCode)
				{
					var readTask = result.Content.ReadAsAsync<OfficeDetails[]>();
					readTask.Wait();
					officeDetails = readTask.Result.ToList();
				}
				else
				{
					officeDetails = Enumerable.Empty<OfficeDetails>().ToList();
					ModelState.AddModelError(string.Empty, "server error.please ");
				}
				return View(officeDetails);

			}
		}

		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult AddOfficeDetails(OfficeDetails user)
		{
			int RecordsAdded = 0;
			// if (!ModelState.IsValid)
			// return BadRequest("Not a valid Model");

			using (client = new HttpClient())
			{
				client.BaseAddress = new Uri("https://localhost:44309/api/");
				//HTTP POST
				var postTask = client.PostAsJsonAsync<OfficeDetails>("OfficeDetails", user);
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
			return RedirectToAction("GetOfficeDetails");
		}



		[HttpGet]
		public ActionResult GetOfficeDetailById(int userid)
		{
			OfficeDetails user = null;
			using (client = new HttpClient())
			{
				client.BaseAddress = new Uri("https://localhost:44309/api/");
				//HTTP GET
				var responseTask = client.GetAsync("OfficeDetails?gId=" + userid);
				responseTask.Wait();
				var result = responseTask.Result;
				if (result.IsSuccessStatusCode)
				{
					var readTask = result.Content.ReadAsAsync<OfficeDetails>();
					readTask.Wait();
					user = readTask.Result;
				}
			}
			return View(user);
		}



		public ActionResult DeleteOfficeDetails(int userid)
		{
			var RecordsModified = 0;
			using (client = new HttpClient())
			{
				client.BaseAddress = new Uri("https://localhost:44309/api/");
				var postTask = client.DeleteAsync("OfficeDetails/?userid=" + userid);
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
			return RedirectToAction("GetOfficeDetails");
		}





		[HttpGet]
		public ActionResult EditOfficeDetails(int grdId)
		{
			OfficeDetails grd = null;
			//var RecordsModified = 0;
			using (client = new HttpClient())
			{
				client.BaseAddress = new Uri("https://localhost:44309/api/");
				// HTTP GET the grade by passing the grade Id
				var responseTask = client.GetAsync($"OfficeDetails/?gId={grdId}");
				responseTask.Wait();
				var result = responseTask.Result;
				if (result.IsSuccessStatusCode)
				{
					var readTask = result.Content.ReadAsAsync<OfficeDetails>();
					readTask.Wait();
					grd = readTask.Result;
				}
			}
			return View(grd);
		}

		[HttpPost]
		public ActionResult EditOfficeDetails(OfficeDetails grd)
		{
			int RecordsModified = 0;
			using (client = new HttpClient())
			{
				client.BaseAddress = new Uri("https://localhost:44309/api/");
				// Http Get all the grades as an array of grade objects
				var postTask = client.PostAsJsonAsync("OfficeDetails/?uid=" + grd.officeid, grd);
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
			return RedirectToAction("GetOfficeDetails");
		}
	}
}
