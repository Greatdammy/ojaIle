using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Ojaile.Consume.Models;
using System.Text;

namespace Ojaile.Consume.Controllers
{
    public class AuthController : Controller
    {
        private readonly IConfiguration _configuration;
        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Login()
        {
            LoginViewModel vm = new LoginViewModel();
            return View(vm);
        }

        
        public async Task< IActionResult> Register()
        {
            //AuthModelComponent authModelComponent = new AuthModelComponent();
            //authModelComponent.user = new RegisterViewModel();

            var authModelComponent = new AuthModelComponent
            {
                user = new RegisterViewModel()
            };
            string endpoint = _configuration["BaseUrl"] + "Account/allUsers";
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(endpoint);
                var content = await response.Content.ReadAsStringAsync();
                authModelComponent.register = JsonConvert.DeserializeObject<List<RegisterViewModel>>(content);
            }

                return View(authModelComponent);
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromForm] AuthModelComponent model)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(model.user), Encoding.UTF8, "application/json");
            string endpoint = _configuration["BaseUrl"] + "Account/Register";
            using (HttpClient client = new HttpClient())
            {
                var Response = await client.PostAsync(endpoint, content);



                if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    //TempData["Profile"] = JsonConvert.SerializeObject(model);
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.Clear();
                    ModelState.AddModelError(string.Empty, "Username already exist");
                    return View();
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromForm] LoginViewModel model)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            string endpoint = _configuration["BaseUrl"] + "Account/Login";
            using (HttpClient client = new HttpClient())
            {
                var Response = await client.PostAsync(endpoint, content);



                if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = await Response.Content.ReadAsStringAsync();
                    TempData["token"] = result; // JsonConvert.DeserializeObject<string>(result);
                    TempData["LoginSucessful"] = "Login sucessful !";
                    //TempData["Profile"] = JsonConvert.SerializeObject(model);
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.Clear();
                    ModelState.AddModelError(string.Empty, "Username already exist");
                    return View();
                }
            }
        }
    }
}
