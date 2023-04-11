using Microsoft.AspNetCore.Http;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.ViewModel
{
    public class StudentViewModel
    {
        [Key]
        public int StudentId { get; set; }
        [Display(Name ="Full Name")]
        public string FullName { get; set; }
        [Display(Name = "First Name")]
        [StringLength(60, MinimumLength = 3)]
        [Required (ErrorMessage ="First Name is Required")]
        public string FirstName { get; set; }
        public string MidName { get; set; }
        [Required(ErrorMessage = "Last Name is Required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Address is Required")]
        public string Address { get; set; }
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Join date  is required")]
        public DateTime JoinDate { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }
        public bool IsActive { get; set; }
        public string ProfilePicture { get; set; }
        public string ProfilePictureFilePath { get; set; }

        //[Required(ErrorMessage = "Please choose profile image")]
        //[RegularExpression(@"(.*\.)(jpg|JPG|gif|GIF|png|PNG)$", ErrorMessage = "Only Image files are allowed!!(.jpg, png, jpeg, gif)")]
        [Display(Name = "Profile Picture")]
        public IFormFile ProfileImage { get; set; } 

        [Display(Name = "Course")]
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string FacultyName { get; set; }
        public List<FacultyModel> FacultyList { get; set; }
        public List<StudentAcademic> AcademicList { get; set; }
        [Display(Name = "Faculty")]
        public int FacultyId { get; set; }

        [ForeignKey("FacultyId")]
        public virtual FacultyModel Faculties { get; set; }

        [NotMapped]
        public List<Course> CourseList { get; set; }
    }
}
