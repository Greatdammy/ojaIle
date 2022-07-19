using System.ComponentModel.DataAnnotations;

namespace ojaIle.webapi.Controllers.Data
{
    public class Country
    {
        [MaxLength(50)]
        public string? Name { get; set; }
        public string? CountryCode { get; set; }
        public int Id { get; set; }
    }
}
