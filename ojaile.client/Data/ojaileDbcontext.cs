using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ojaile.client.Model;

namespace ojaile.client.Data
{
    public class ojaileDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public ojaileDbContext(DbContextOptions<ojaileDbContext> options)
            : base(options)
        {

        } 
        //public DbSet<Country> Countries { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.Entity<Country>(c =>
            //{
            //    c.HasKey(p => p.Id);
            //});

            //builder.Entity<Country>(c =>
            //{
            //    c.HasNoKey();
            //});
        }
    }
    
}
