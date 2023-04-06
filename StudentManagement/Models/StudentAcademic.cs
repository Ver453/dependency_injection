using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public class StudentAcademic
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Qualification is required")]
        public string Qualification { get; set; }
        [Required(ErrorMessage = "Enter a valid year")]
        [RegularExpression(@"^(\d{4})$", ErrorMessage = "Enter a valid 4 digit Year")]
        public string PassedYear { get; set; }
        [Required(ErrorMessage = "Enter a valid marks")]
        [RegularExpression(@"^(\d{2})$", ErrorMessage = "Enter a valid 2 digit marks")]
        public int Marks { get; set; }
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public virtual StudentModel Students { get; set; }
    }
}
