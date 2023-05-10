
using Microsoft.EntityFrameworkCore;
using StudentManagement.Business_Layer.Repository;
using StudentManagement.Interface;
using StudentManagement.Models;
using StudentManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Business_Layer
{
    public class CourseBL:ICourse
    {
        private readonly IBaseRepository _baseRepository;


        public CourseBL(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public async Task<CourseViewModel> GetCreateData()
        {
            CourseViewModel courseModel = new CourseViewModel();
            courseModel.FacultyList = await _baseRepository.GetAllData<FacultyModel>().ToListAsync();
            return courseModel;
        }

        public async Task<Course> PostCreateData(CourseViewModel course)
        {

            try
            {
                var model = new Course
                {
                    Name = course.Name,
                    FacultyId = course.FacultyId
                };
                var result = await _baseRepository.Add<Course>(model);

                return model;
            }

            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<List<CourseViewModel>> GetAllCourses()  
        {
            var course = from c in    _baseRepository.GetAllData<Course>()
                         join f in   _baseRepository.GetAllData<FacultyModel>()
                         on c.FacultyId equals f.FacultyId
                         select new CourseViewModel
            {
                Id = c.Id,
                Name = c.Name,
                FacultyId = f.FacultyId,
                FacultyName=f.FacultyName

            };
            return await course.ToListAsync();
        }
    }
}
