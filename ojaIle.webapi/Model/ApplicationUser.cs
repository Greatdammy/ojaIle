﻿using Microsoft.AspNetCore.Identity;

namespace ojaIle.webapi.Model
{
    public class ApplicationUser : IdentityUser
    {

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Institution { get; set; }
        public DateTime Created { get; set; }
        public string? ProductName { get; set; }
        public string? PhoneNumber { get; set; }

    }


}
