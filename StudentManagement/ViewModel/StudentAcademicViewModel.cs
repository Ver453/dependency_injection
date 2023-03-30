using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.ViewModel
{
    public class StudentAcademicViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Qualification is required")]
        public string Qualification { get; set; }
        [Required(ErrorMessage = "Enter a valid year")]
        public DateTime PassedYear { get; set; }
        [Required(ErrorMessage = "Enter a valid marks")]
        public int Marks { get; set; }
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public virtual StudentModel Students { get; set; }
    }
}
