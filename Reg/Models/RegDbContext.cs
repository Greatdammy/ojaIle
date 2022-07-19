using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Reg.Controllers;

namespace Reg.Models
{
    public class RegDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public RegDbContext(DbContextOptions<RegDbContext> options) : base(options)
        {

        }
        public DbSet<RegView> RegControllers { get; set; }
    }
}
