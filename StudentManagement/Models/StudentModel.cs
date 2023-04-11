using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public class StudentModel
    {
        
        [Key]
        public int StudentId { get; set; }
        [Required(ErrorMessage ="First Name is Required")]
        public string FirstName { get; set; }
        public string MidName { get; set; }
        [Required(ErrorMessage = "Last Name is Required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Address is Required")]
        public string Address { get; set; }
        [DataType(DataType.Date)]
        public DateTime JoinDate { get; set; } = DateTime.Now;
        [Range(1, int.MaxValue, ErrorMessage = "Gender is Required")]
        public string Gender { get; set; }
        public bool IsActive { get; set; }
        public string ProfilePicture { get; set; }

        [Display(Name ="Faculty")]
        public int FacultyId { get; set; }
        [Display(Name = "Course")]
        public int CourseId { get; set; }
        [ForeignKey("FacultyId")]
        public virtual FacultyModel Faculties { get; set; }

        public virtual List<StudentAcademic> AcademicDetails { get; set; }

        [NotMapped]
        public List<Course> CourseList { get; set; }
    }
}
