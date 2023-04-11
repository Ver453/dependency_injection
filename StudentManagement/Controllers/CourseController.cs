using Microsoft.AspNetCore.Mvc;
using StudentManagement.Data;
using StudentManagement.Interface;
using StudentManagement.Models;
using StudentManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Controllers
{
    public class CourseController : Controller
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
        public IActionResult Create()
        {
            var getCreateData = _course.GetCreateData();
            return View(getCreateData);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CourseViewModel viewmodel)
        {
            var postCreateCourse = _course.PostCreateData(viewmodel);
            return RedirectToAction("Create");
        }

    }

}