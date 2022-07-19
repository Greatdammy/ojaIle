using Microsoft.AspNetCore.Identity;

namespace ojaile.client2.Model
{
    public class ApplicationUser
    {
        public class ApplicationUsers : IdentityUser
        {
            public string? FirstName { get; set; }
            public string? LastName { get; set; }

            public int Institution { get; set; }

            public DateTime Created { get; set; }

            public string? ProductName { get; set; }
        }
    }
}

