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
    public class FacultyController : Controller
    {
        private readonly IFaculty _faculty;

        public FacultyController(IFaculty faculty)
        {
            _faculty = faculty;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FacultyViewModel faculty)
        {
            if (ModelState.IsValid)
            {
                var postCreateData = _faculty.PostCreateData(faculty);
                return RedirectToAction("Create");
            }
            return View();
        }
    }
}
