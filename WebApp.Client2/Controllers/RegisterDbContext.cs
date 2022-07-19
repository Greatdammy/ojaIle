using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp.Client2.Models;

namespace WebApp.Client2.Controllers
{
    public class RegisterDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    { 
        public RegisterDbContext(DbContextOptions<RegisterDbContext> options) : base(options)
        {

        }
        public DbSet<RegisterController> RegisterControllers { get; set; }
    }
}
