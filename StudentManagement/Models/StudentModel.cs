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
        [StringLength(60, MinimumLength = 3)]
        public string FirstName { get; set; }
        public string MidName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        [DataType(DataType.Date)]
        public DateTime JoinDate { get; set; } = DateTime.Now;
        public string Gender { get; set; }
        public bool IsActive { get; set; }

        //[Required(ErrorMessage = "Please choose profile image")]
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
