using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Reg.Models;

namespace Reg.Controllers
{
    public class RegView : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        


        public RegController(UserManager<ApplicationUser> userManager)
        {

            _userManager = userManager;
            
        }

        [BindProperty]
        public RegViewModel model { get; set; }
        public IActionResult Index()
        {
           
            return View();
        }



        [HttpPost]

        public async Task<IActionResult> Reg()
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
            }
            return BadRequest(ModelState);

        }

        //ViewData["RegisteredName"] = fname + " " + lname + "has sucessfully registered ";



    }
}


   

