using Microsoft.EntityFrameworkCore;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentManagement.ViewModel;

namespace StudentManagement.Data
{
    public class AppDbContext:DbContext
    {
        
        public AppDbContext(DbContextOptions<AppDbContext> options):base (options)
        {
           
        }
        public DbSet<StudentModel> Students { get; set; }
        public DbSet<FacultyModel> Faculties { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentAcademic> Academics { get; set; }
        public DbSet<UserRegistration> Registers { get; set; }
        //public DbSet<StudentManagement.ViewModel.StudentViewModel> StudentViewModel { get; set; }

    }
}
