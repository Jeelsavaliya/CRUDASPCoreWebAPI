using CRUDASPCoreWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CRUDASPCoreWebAPI.Controllers
{
    public class StudentController : Controller
    {
        private string url = "https://localhost:7148/api/Student/";
        private HttpClient client = new HttpClient();


        #region List Of Student
        [HttpGet]
        public IActionResult Index()
        {
            List<Students> students = new List<Students>();
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

            string data = JsonConvert.SerializeObject(std);
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
            Students students = new Students();
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
            string data = JsonConvert.SerializeObject(std);
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
            Students students = new Students();
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
            Students students = new Students();
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
