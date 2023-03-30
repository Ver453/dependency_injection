﻿using Microsoft.AspNetCore.Http;
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
        [StringLength(60, MinimumLength = 3)]

        [Required]
        public string FirstName { get; set; }
        public string MidName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime JoinDate { get; set; }
        public string Gender { get; set; }
        public bool IsActive { get; set; }
        public string ProfilePicture { get; set; }

        //[Required(ErrorMessage = "Please choose profile image")]
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