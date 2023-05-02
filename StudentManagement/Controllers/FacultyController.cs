using Microsoft.AspNetCore.Mvc;
using StudentManagement.Data;
using StudentManagement.Infrastructure;
using StudentManagement.Infrastructure.Enums;
using StudentManagement.Interface;
using StudentManagement.Models;
using StudentManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Controllers
{
    public class FacultyController : BaseController
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
        public async Task<IActionResult> Create(FacultyViewModel faculty)
        {
            if (ModelState.IsValid)
            {
                var postCreateData = await _faculty.PostCreateData(faculty);
                 TempData["ResultOk"] = "Faculty sucessfully Created!";
                return Json(new DataResult { ResultType = ResultType.Success, Message = "Success" });
            }
            return Json(new DataResult { ResultType = ResultType.Failed, Message = "Failed" });
        }
    }
}
