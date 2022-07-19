using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OjaIle.data.Model
{
    public class PropertyItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string PropertyName { get; set; }
        public int PropertytTypeId { get; set; }
        public string UserId { get; set; }
        public string PropertyDescription { get; set; }
        public string Address { get; set; }
        public virtual int LGA { get; set; }
        public int StateId { get; set; }
        public DateTime Created { get; set; }
        public int ContryId { get; set; }
        public string CreatedBy { get; set; }



    }
}