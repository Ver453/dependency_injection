﻿using StudentManagement.Models;
using StudentManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Interface
{
   public interface IStudent
    {
        StudentViewModel GetData(int Id);
        List<StudentViewModel> GetIndexData();
        StudentViewModel GetCreateData();
        DashboardViewModel studentdata();
        List<CourseViewModel> GetCourseListByFacultyId(int Id);
        StudentModel PostCreateData(StudentViewModel student);
        int PostEditData(StudentViewModel student);
        int PostDeleteData(StudentViewModel student);
    }
}
