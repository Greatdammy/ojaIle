using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ojaile.client2.Data;
using ojaIle.webapi.Model;

namespace ojaile.client2.Pages
{
    public class RegisterPageModel : PageModel
    {
        
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ojaileDbContext _dbContext;

        public RegisterPageModel(UserManager<ApplicationUser> userManager, ojaileDbContext dbContext)
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }

        public void OnGet()
        {
        }

        [BindProperty]
        public RegisterViewModel register { get; set; }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ApplicationUser user = new ApplicationUser();
            user.Email = register.Email;
            user.FirstName = register.FirstName;
            user.LastName = register.LastName;
            user.PhoneNumber = register.phoneNumber;
            user.UserName = register.UserName;
            user.Created = DateTime.Now;
            user.Institution = 1;

            var result = await _userManager.CreateAsync(user, register.Password);

            if (result.Succeeded)
            {
                ViewData["RegisteredName"] = register.FirstName + ' ' + register.LastName + " has successfully Registered!";
                Users();
                return Page();
                //return RedirectToPage("Index");
            }
            return BadRequest(ModelState);


        }
        public List<ApplicationUser> Users()
        {
            return _dbContext.Users.ToList();
        }
        //public void OnPost()
        //{
        //    //var fname = Request.Form["firstName"];
        //   // var lname = Request.Form["lastName"];

        //    ViewData["RegisteredName"] = register.FirstName + ' ' + register.LastName + " has successfully Registered!";
        //}
    }
}
    
