using Microsoft.AspNetCore.Mvc;
using StudentManagement.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Controllers
{
    public class StudentAcademicController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
