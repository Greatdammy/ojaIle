using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Client2.Controllers;
using WebApp.Client2.Models;

namespace WebApp.Client2.Views.Register
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public RegisterViewModel register { get; set; }
        public void OnGet()
        {
        }

        public void Post()
        {
            //var fname = Request.Form["Firstname"];
            //var lname = Request.Form["Lastname"];
            //return Page();

            ViewData["RegisteredName"] = register.FirstName + " " + register.LastName + "has sucessfully registered ";

        }
    }
}
