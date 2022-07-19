using System;
using System.Collections.Generic;

namespace OjaIle.data.Models
{
    public partial class Country
    {
        public Country()
        {
            PropertyItems = new HashSet<PropertyItem>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? CountryCode { get; set; }

        public virtual ICollection<PropertyItem> PropertyItems { get; set; }
    }
}
