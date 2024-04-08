using CRUDASPCoreWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CRUDASPCoreWebAPI.Controllers
{
    public class StudentController : Controller
    {
        private string url = "https://localhost:7148/api/Student/";
        private HttpClient client = new HttpClient();

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

        public IActionResult Create()
        {
            return View();
        }
    }
}
