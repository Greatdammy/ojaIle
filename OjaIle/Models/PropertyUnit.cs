using System;
using System.Collections.Generic;

namespace OjaIle.data.Models
{
    public partial class PropertyUnit
    {
        public PropertyUnit()
        {
            PropertyDocuments = new HashSet<PropertyDocument>();
            PropertyImages = new HashSet<PropertyImage>();
            ServicePropertyUnits = new HashSet<ServicePropertyUnit>();
        }

        public int Id { get; set; }
        public int? PropertyId { get; set; }
        public string? UnitName { get; set; }
        public string? UnitDescription { get; set; }
        public bool? AvalabilityStatus { get; set; }
        public bool? PublishingStatus { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? Created { get; set; }
        public string? UserId { get; set; }

        public virtual AspNetUser? CreatedByNavigation { get; set; }
        public virtual PropertyItem? Property { get; set; }
        public virtual AspNetUser? User { get; set; }
        public virtual ICollection<PropertyDocument> PropertyDocuments { get; set; }
        public virtual ICollection<PropertyImage> PropertyImages { get; set; }
        public virtual ICollection<ServicePropertyUnit> ServicePropertyUnits { get; set; }
    }
}
