using Microsoft.AspNetCore.Mvc;
using StudentManagement.Business_Layer;
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
    public class StudentController : Controller
    {
        private readonly IStudent _student;

        public StudentController(IStudent student)
        {
            _student = student;
        }
        [HttpGet]
        public IActionResult Index(string SearchString)
        {
            if(SearchString != null)
            {
                ViewData["studentdata"] = SearchString;
                var student = from c in _student.GetIndexData()
                              select c;
                if (!String.IsNullOrEmpty(SearchString))
                {
                    student = student.Where(c => c.StudentId.ToString().Contains(SearchString));
                }
                return View(student);
            }
            
            var getIndexData = _student.GetIndexData();
            return View(getIndexData);

        }
        [HttpGet]
        public IActionResult Create()
        {
            var getCreateData = _student.GetCreateData();
            return View(getCreateData);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StudentViewModel student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //ViewBag.Message = "Data created!";
                    if (student.AcademicList == null)
                    {
                        var getCreateData = _student.GetCreateData();

                        student.FacultyList = getCreateData.FacultyList;
                        student.CourseList = getCreateData.CourseList;
                        TempData["ResultError"] = "Error occured!";
                        return View(student);
                    }

                    var result = _student.PostCreateData(student);
                    if (result != null)
                    {
                        TempData["ResultOk"] = "Recored is sucessfully Added!";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["ResultError"] = "Error occured!";
                    }
                    if (student.ProfileImage.Length > 2000000)
                    {
                        ModelState.AddModelError("ProfileImage", "Image must be less than 2 Mb");
                    }
                }
                else{
                    var getCreateData = _student.GetCreateData();

                    student.FacultyList = getCreateData.FacultyList;
                    student.CourseList = getCreateData.CourseList;
                    TempData["ResultError"] = "Error occured!";
                    return View(student);
                }
            }
            catch (Exception ex)
            {
            }
            return View(student);
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var getdata = _student.GetData(Id);
            return View(getdata);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(StudentViewModel student)
        {
            if (ModelState.IsValid)
            {
                if (student.ProfileImage.Length > 1024)
                {
                    ModelState.AddModelError("", "Image must be less than 1 Mb");
                }
                var postEditData = _student.PostEditData(student);
                if (postEditData != null)
                {
                    TempData["ResultOk"] = "Recored is sucessfully Edited!";
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Edit");
                }
            }
            return View(student);
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var getdeletedata = _student.GetData(Id);
            return View(getdeletedata);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(StudentViewModel student)
        {
            var postDeleteData = _student.PostDeleteData(student);
            TempData["ResultOk"] = "Recored is sucessfully Deleated!";
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Details(int Id)
        {
            var getDetailsData = _student.GetData(Id);
            return View(getDetailsData);
        }
        [HttpGet]
        public List<CourseViewModel> GetDataByFaculty(int Id)
        {
            var getCourseByFaculty = _student.GetCourseListByFacultyId(Id);
            return getCourseByFaculty;
        }

    }
}
