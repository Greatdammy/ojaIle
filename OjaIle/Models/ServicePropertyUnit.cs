using System;
using System.Collections.Generic;

namespace OjaIle.data.Models
{
    public partial class ServicePropertyUnit
    {
        public int Id { get; set; }
        public int? ServiceId { get; set; }
        public int? PropertyUnitId { get; set; }
        public decimal? Price { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? Created { get; set; }

        public virtual AspNetUser? CreatedByNavigation { get; set; }
        public virtual PropertyUnit? PropertyUnit { get; set; }
        public virtual ServiceAvailable? Service { get; set; }
    }
}
