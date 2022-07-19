using System;
using System.Collections.Generic;

namespace OjaIle.data.Models
{
    public partial class PropertyDocument
    {
        public int Id { get; set; }
        public int? PropertyUnitId { get; set; }
        public string? DocumentUrl { get; set; }

        public virtual PropertyUnit? PropertyUnit { get; set; }
    }
}
