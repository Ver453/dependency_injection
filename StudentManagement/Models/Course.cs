using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Faculty")]
        public int FacultyId { get; set; }
        [ForeignKey("FacultyId")]
        public virtual FacultyModel Faculties { get; set; }
    }
}
