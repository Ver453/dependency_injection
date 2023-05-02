using Microsoft.AspNetCore.Mvc;
using StudentManagement.Data;
using StudentManagement.Infrastructure;
using StudentManagement.Interface;
using StudentManagement.Models;
using StudentManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Controllers
{
    public class CourseController : BaseController
    {
        private readonly ICourse _course;

        public CourseController(ICourse course)
        {
            _course = course;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var getCreateData = await _course.GetCreateData();
            return View(getCreateData);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<Course> Create(CourseViewModel model)
        {
            var postCreateCourse = await _course.PostCreateData(model);
            return postCreateCourse;

            //return RedirectToAction("Create");
        }
        [HttpGet]
        public async Task<List<CourseViewModel>> GetAllCourses()
        {
            var getData =await _course.GetAllCourses();
            return getData;
        }
    }

}