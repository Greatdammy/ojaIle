using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Web.Helpers;
using WebApp.Client2.Models;
using static System.Net.Mime.MediaTypeNames;

namespace WebApp.Client2.Controllers
{
    public class RegisterController : Controller
    {

       
        private readonly UserManager<ApplicationUser> _userManager;
        //private readonly SignInManager<ApplicationUser> _signInManager;


        public RegisterController(UserManager<ApplicationUser> userManager)
        {
          
            _userManager = userManager;
            //_logger = logger;
            //_signInManager = signInManager;
        }

       // [BindProperty]
        //public RegisterViewModel model { get; set; }
        public IActionResult Index()
        {
            //ViewData["RegisteredName"] = "";
            return View();
        }


        //public ActionResult Reg


        // var fname = Request.Form["Firstname"];
        //var lname = Request.Form["Lastname"];

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(ModelState);
            }

            var user = new ApplicationUser();
            user.Email = model.Email;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.PhoneNumber = model.phoneNumber;
            user.UserName = model.UserName;
            user.Created = DateTime.Now;
            user.Institution = 1;

            var result = await _userManager.CreateAsync(user, model.UserName);

            if (result.Succeeded)
            {
               // StringContent content = new StringContent(JsonConvert.SerializeObject(model.UserName), Encoding.UTF8, "application/json");
                ViewData["RegisteredName"] = model.FirstName + " " + model.LastName + "has sucessfully registered ";
                // return View("RegisteredName");
                //return Ok(result);
                // Content - Type: Application / Json
                return RedirectToPage("Index");
            }
            return BadRequest(ModelState);
            //return BadRequest(ModelState);
            //return View("Index");

        }

        //ViewData["RegisteredName"] = fname + " " + lname + "has sucessfully registered ";



    }
}
