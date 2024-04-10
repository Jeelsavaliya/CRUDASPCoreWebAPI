using CRUDASPCoreWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NuGet.Common;
using System.Net.Http.Headers;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CRUDASPCoreWebAPI.Controllers
{
    /*[Authorize(AuthenticationSchemes = "Bearer")]*/

        
    public class StudentController : Controller
    {
        private string url = "https://localhost:7148/api/Student/";
        private HttpClient client = new HttpClient();

        #region List Of Student
        [HttpGet]
        public IActionResult Index()
        {
            //Get Token
            var _token = HttpContext.Session.GetString("token");

            List<Students> students = new List<Students>();

            //Use token for Authorization
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<List<Students>>(result);
                if (data != null)
                {
                    students = data;
                }
            }
            return View(students);
        }
        #endregion

        #region Add Student
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Students std)
        {
            var _token = HttpContext.Session.GetString("token");

            string data = JsonConvert.SerializeObject(std);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(url, content).Result;

            if (response.IsSuccessStatusCode)
            {
                TempData["Insert_Massage"] = "Student Added...";
                return RedirectToAction("Index");
            }

            return View();
        }
        #endregion

        #region Update Student
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var _token = HttpContext.Session.GetString("token");

            Students students = new Students();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            HttpResponseMessage response = client.GetAsync(url + id).Result;

            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Students>(result);
                if (data != null)
                {
                    students = data;
                }
            }
            return View(students);
        }

        [HttpPost]
        public IActionResult Edit(Students std)
        {
            var _token = HttpContext.Session.GetString("token");

            string data = JsonConvert.SerializeObject(std);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(url + std.Id, content).Result;

            if (response.IsSuccessStatusCode)
            {
                TempData["Edit_Massage"] = "Student Edit...";
                return RedirectToAction("Index");
            }

            return View();
        }
        #endregion

        #region Details Of student
        public IActionResult Details(int id)
        {
            var _token = HttpContext.Session.GetString("token");

            Students students = new Students();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            HttpResponseMessage response = client.GetAsync(url + id).Result;

            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Students>(result);
                if (data != null)
                {
                    students = data;
                }
            }
            return View(students);
        }
        #endregion

        #region Delete Student
        public IActionResult Delete(int id)
        {
            var _token = HttpContext.Session.GetString("token");

            Students students = new Students();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            HttpResponseMessage response = client.GetAsync(url + id).Result;

            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Students>(result);
                if (data != null)
                {
                    students = data;
                }
            }
            return View(students);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult ConformDelete(int id)
        {
            var _token = HttpContext.Session.GetString("token");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            HttpResponseMessage response = client.DeleteAsync(url + id).Result;

            if (response.IsSuccessStatusCode)
            {
                TempData["Delete"] = "Student Deleted...";
                return RedirectToAction("Index");
            }

            return View();
        }
        #endregion
    }

}
