using Microsoft.AspNetCore.Mvc;
using StudentManagement.Business_Layer;
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
    public class StudentController :BaseController
    {
        private readonly IStudent _student;

        public StudentController(IStudent student)
        {
            _student = student;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string SearchString)
        {
            if(SearchString != null)
            {
                ViewData["studentdata"] = SearchString;
                var student = from c in await _student.GetIndexData()
                              select c;
                if (!String.IsNullOrEmpty(SearchString))
                {
                    student = student.Where(c => c.StudentId.ToString().Contains(SearchString));
                }
                return View(student);
            }
            
            var getIndexData = await _student.GetIndexData();
            return View(getIndexData);

        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var getCreateData = await _student.GetCreateData();
            return View(getCreateData);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentViewModel student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //ViewBag.Message = "Data created!";
                    if (student.AcademicList == null)
                    {
                        var getCreateData =await _student.GetCreateData();

                        student.FacultyList = getCreateData.FacultyList;
                        student.CourseList = getCreateData.CourseList;
                        TempData["ResultError"] = "Error occured!";
                        ModelState.AddModelError("AcademicList_0__Qualification", "This field is required");
                        return Json( new DataResult { ResultType = ResultType.Failed, Message="Failed"});
                        //return View(student);
                    }

                    var result = await _student.PostCreateData(student);
                    if (result != null)
                    {
                        TempData["ResultOk"] = "Recored is sucessfully Added!";
                        return Json(new DataResult { ResultType = ResultType.Success, Message = "success" });
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
                    var getCreateData = await _student.GetCreateData();

                    student.FacultyList = getCreateData.FacultyList;
                    student.CourseList = getCreateData.CourseList;
                    TempData["ResultError"] = "Error occured!";
                    return Json( new DataResult { ResultType = ResultType.Failed, Message = String.Join(";",ModelState.Values.SelectMany(x=>x.Errors).Select(x=>x.ErrorMessage)) }); 
                }
            }
            catch (Exception ex)
            {
                return Json(new DataResult { ResultType = ResultType.Failed, Message = "Failed" });
            }
            return Json(new DataResult { ResultType = ResultType.Failed, Message = "Failed" });
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var getdata = await _student.GetData(Id);
            return View(getdata);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(StudentViewModel student)
        {
            if (ModelState.IsValid)
            {
                var postEditData =await _student.PostEditData(student);
                if (postEditData != null)
                {
                    TempData["ResultOk"] = "Recored is sucessfully Edited!";
                    return Json(new DataResult { ResultType = ResultType.Success, Message = "success" });
                }
                else
                {

                    TempData["ResultError"] = "Error occured!";
                    return Json(new DataResult { ResultType = ResultType.Failed, Message = "Failed" });
                }
                if (student.ProfileImage.Length > 2000000)
                {
                    ModelState.AddModelError("ProfileImage", "Image must be less than 2 Mb");
                }
            }
            return Json(new DataResult { ResultType = ResultType.Failed, Message = "Failed" });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            var getdeletedata = await _student.GetData(Id);
            return View(getdeletedata);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(StudentViewModel student)
        {
            var postDeleteData = await _student.PostDeleteData(student);
            TempData["ResultOk"] = "Recored Deleated!";
            return Json(new DataResult { ResultType = ResultType.Success, Message = "Success" });
        }


        [HttpGet]
        public async Task<IActionResult> Details(int Id)
        {
            var getDetailsData = await _student.GetData(Id);
            return View(getDetailsData);
        }
        [HttpGet]
        public async Task<List<CourseViewModel>> GetDataByFaculty(int Id)
        {
            var getCourseByFaculty = await _student.GetCourseListByFacultyId(Id);
            return getCourseByFaculty;
        }

    }
}
