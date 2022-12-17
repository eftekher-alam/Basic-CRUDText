using System.ComponentModel.DataAnnotations;

namespace BasicCRUDText.Models
{
    public class Department
    {
        [Key]
        public int DepId { get; set; }
        [Required]
        [Display(Name = "Department Name")]
        public string  DeptName { get; set; }

        public ICollection<Student>? Students { get; set; }
    }
}
