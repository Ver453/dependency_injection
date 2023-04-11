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

        public CourseViewModel GetCreateData()
        {
            CourseViewModel courseModel = new CourseViewModel();
            courseModel.FacultyList = _baseRepository.GetAllData<FacultyModel>().ToList();
            return courseModel;
        }

        public int PostCreateData(CourseViewModel course)
        {
            try
            {
                var model = new Course
                {
                    Name = course.Name,
                    FacultyId = course.FacultyId
                };
                var result = _baseRepository.Create<Course>(model);

                return 1;
            }

            catch (Exception ex)
            {

                throw;
            }
        }


    }
}
