﻿using System;
using System.Collections.Generic;

namespace OjaIle.data.Models
{
    public partial class Lga
    {
        public Lga()
        {
            PropertyItems = new HashSet<PropertyItem>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<PropertyItem> PropertyItems { get; set; }
    }
}
