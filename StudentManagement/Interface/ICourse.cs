using StudentManagement.Models;
using StudentManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Interface
{
    public interface ICourse
    {
        //int  PostCreateData(CourseViewModel course);
        Task<Course> PostCreateData(CourseViewModel course);
        Task<CourseViewModel> GetCreateData();
        Task<List<CourseViewModel>> GetAllCourses();
    }
}
