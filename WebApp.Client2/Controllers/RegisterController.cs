using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using WebApp.Client2.Models;

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

        [BindProperty]
        public RegisterViewModel model { get; set; }
        public IActionResult Index()
        {
            //ViewData["RegisteredName"] = "";
            return View();
        }

     
        //public ActionResult Reg

        [HttpPost]
      
           // var fname = Request.Form["Firstname"];
            //var lname = Request.Form["Lastname"];
            public async Task<IActionResult> OnPost()
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

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    ViewData["RegisteredName"] = model.FirstName + " " + model.LastName + "has sucessfully registered ";
                     return View("RegisteredName");
                return Ok(result);
                return RedirectToPage("Index");
                }
                        return BadRequest(ModelState);
                 return BadRequest(ModelState);
                 return View("Index");

            }

            //ViewData["RegisteredName"] = fname + " " + lname + "has sucessfully registered ";
            
        

    }
}
