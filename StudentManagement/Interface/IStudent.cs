using StudentManagement.Models;
using StudentManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Interface
{
    public interface IStudent
    {
        Task<StudentViewModel> GetData(int Id);
        Task<List<StudentViewModel>> GetIndexData();
        Task<StudentViewModel> GetCreateData();
        DashboardViewModel studentdata();
        Task<List<CourseViewModel>> GetCourseListByFacultyId(int Id);
        Task<StudentModel> PostCreateData(StudentViewModel student);
        Task<StudentModel> PostEditData(StudentViewModel student);
        Task<int> PostDeleteData(StudentViewModel student);
    }
}
