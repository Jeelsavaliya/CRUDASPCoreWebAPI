using CRUDASPCoreWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol;
using System.Net.Http.Headers;
using System.Text;

namespace CRUDASPCoreWebAPI.Controllers
{
    public class LoginController : Controller
    {
        private string url = "https://localhost:7148/api/Login/";
        private HttpClient client = new HttpClient();

        #region Login
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserModel userModel)
        {

            client.BaseAddress = new Uri(url);
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);

            string stringData = JsonConvert.SerializeObject(userModel);
            var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync("/api/Login", contentData).Result;

            var stringJWT = response.Content.ReadAsStringAsync().Result;

            var jwt = JsonConvert.DeserializeObject<string>(stringJWT) ?? "";


            HttpContext.Session.SetString("token", jwt);

            ViewBag.Message = "User logged in successfully!";

            return RedirectToAction("Index", "Student");

        }
        #endregion

        #region Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("token");
            ViewBag.Message = "User logged out successfully!";
            return View("Login");
        }
        #endregion

    }
}
