using System;
using System.Collections.Generic;

namespace OjaIle.data.Models
{
    public partial class AspNetUser
    {
        public AspNetUser()
        {
            AspNetUserClaims = new HashSet<AspNetUserClaim>();
            AspNetUserLogins = new HashSet<AspNetUserLogin>();
            AspNetUserTokens = new HashSet<AspNetUserToken>();
            PropertyItemCreatedByNavigations = new HashSet<PropertyItem>();
            PropertyItemUsers = new HashSet<PropertyItem>();
            PropertyUnitCreatedByNavigations = new HashSet<PropertyUnit>();
            PropertyUnitUsers = new HashSet<PropertyUnit>();
            ServicePropertyUnits = new HashSet<ServicePropertyUnit>();
            Roles = new HashSet<AspNetRole>();
        }

        public string Id { get; set; } = null!;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Institution { get; set; }
        public DateTime Created { get; set; }
        public string? ProductName { get; set; }
        public string? UserName { get; set; }
        public string? NormalizedUserName { get; set; }
        public string? Email { get; set; }
        public string? NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string? PasswordHash { get; set; }
        public string? SecurityStamp { get; set; }
        public string? ConcurrencyStamp { get; set; }
        public string? PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }

        public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual ICollection<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual ICollection<PropertyItem> PropertyItemCreatedByNavigations { get; set; }
        public virtual ICollection<PropertyItem> PropertyItemUsers { get; set; }
        public virtual ICollection<PropertyUnit> PropertyUnitCreatedByNavigations { get; set; }
        public virtual ICollection<PropertyUnit> PropertyUnitUsers { get; set; }
        public virtual ICollection<ServicePropertyUnit> ServicePropertyUnits { get; set; }

        public virtual ICollection<AspNetRole> Roles { get; set; }
    }
}
