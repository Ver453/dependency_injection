using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Business_Layer.Repository;
using StudentManagement.Data;
using StudentManagement.Interface;
using StudentManagement.Models;
using StudentManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Business_Layer
{
    public class StudentBL : IStudent
    {
        private readonly IBaseRepository _baseRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public StudentBL(IBaseRepository baseRepository, IWebHostEnvironment webHostEnvironment)
        {
            _baseRepository = baseRepository;
            _webHostEnvironment = webHostEnvironment;
        }


        //featch a data....
        public async Task<StudentViewModel> GetData(int Id)
        {

            StudentViewModel studentViewModel =await _baseRepository.GetAllData<StudentModel>().Where(x => x.StudentId == Id).Select(x => new StudentViewModel
            {
                StudentId = x.StudentId,
                FirstName = x.FirstName,
                MidName = x.MidName,
                LastName = x.LastName,
                Address = x.Address,
                JoinDate = x.JoinDate,
                Gender = x.Gender,
                IsActive = x.IsActive,
                FacultyId = x.FacultyId,
                CourseId = x.CourseId,
                ProfilePicture = x.ProfilePicture,
                ProfilePictureFilePath = "/Images/" + x.ProfilePicture,
                FacultyName = x.Faculties.FacultyName,
                AcademicList = x.AcademicDetails.ToList(),
            }).FirstOrDefaultAsync();
            studentViewModel.CourseList =await _baseRepository.GetAllData<Course>().ToListAsync();
            studentViewModel.FacultyList = await _baseRepository.GetAllData<FacultyModel>().ToListAsync();
            studentViewModel.CourseName = studentViewModel.CourseList.Where(y => y.Id == studentViewModel.CourseId).Select(z => z.Name).FirstOrDefault();
            return studentViewModel;
        }

        public DashboardViewModel studentdata()
        {
            DashboardViewModel model = new DashboardViewModel();
            model.StudentCount = _baseRepository.GetAllData<StudentModel>().Count();
            model.FacultyCount = _baseRepository.GetAllData<FacultyModel>().Count();
            model.CourseCount = _baseRepository.GetAllData<Course>().Count();
            return model;
        }

        //Show a data in index page......
        public async Task<List<StudentViewModel>> GetIndexData()
        {
            var std = await _baseRepository.GetAllData<StudentModel>().Select(x => new StudentViewModel
            {
                StudentId = x.StudentId,
                FullName = string.Concat(x.FirstName, " ", x.MidName, " ", x.LastName),
                Address = x.Address,
                JoinDate = x.JoinDate,
                Gender = x.Gender,
                IsActive = x.IsActive,
                FacultyId = x.FacultyId,
                CourseId = x.CourseId,
                ProfilePicture = x.ProfilePicture,
            }).OrderByDescending(z => z.StudentId).ToListAsync();
            return std;
        }

        //Create a data..
        public async Task<StudentViewModel> GetCreateData()
        {
            StudentViewModel studentModel = new StudentViewModel();
            studentModel.CourseList =  await _baseRepository.GetAllData<Course>().ToListAsync();
            studentModel.FacultyList =  await _baseRepository.GetAllData<FacultyModel>().ToListAsync();
            return studentModel;
        }

        public async Task<StudentModel> PostCreateData(StudentViewModel student)
        {
             try
            {
                string uniqueFileName = "";
                if (student.ProfileImage == null)
                {
                    uniqueFileName = "dummy.png";
                }
                else {
                    uniqueFileName = UploadedFile(student);
                }
                var model = new StudentModel
                {
                    FirstName = student.FirstName,
                    MidName = student.MidName,
                    LastName = student.LastName,
                    Address = student.Address,
                    JoinDate = student.JoinDate,
                    Gender = student.Gender,
                    IsActive = student.IsActive,
                    FacultyId = student.FacultyId,
                    CourseId = student.CourseId,
                    ProfilePicture = uniqueFileName,
                    AcademicDetails = student.AcademicList.Select(x => new StudentAcademic {

                        Qualification = x.Qualification,
                        PassedYear = x.PassedYear,
                        Marks = x.Marks,
                    }).ToList()
                };
                var result = await _baseRepository.Create<StudentModel>(model);
                return result;
            }

            catch (Exception ex)
            {

                throw;
            }
        }

        //Edit a data....
        public async Task<StudentModel> PostEditData(StudentViewModel student)
        {
            try
            {
                string uniqueFileName = "";
                if (student.ProfileImage == null)
                {
                    uniqueFileName = student.ProfilePicture;
                }
                else
                {
                    uniqueFileName = UploadedFile(student);
                }
                //string uniqueFileName = UploadedFile(student);
                StudentModel Data = await _baseRepository.GetAllData<StudentModel>().Where(x => x.StudentId == student.StudentId).FirstOrDefaultAsync();

                Data.FirstName = student.FirstName;
                Data.MidName = student.MidName;
                Data.LastName = student.LastName;
                Data.Address = student.Address;
                Data.JoinDate = student.JoinDate;
                Data.Gender = student.Gender;
                Data.IsActive = student.IsActive;
                Data.FacultyId = student.FacultyId;
                Data.CourseId = student.CourseId;
                Data.ProfilePicture = uniqueFileName;

                Data.AcademicDetails = student.AcademicList.Select(y=>new StudentAcademic { 
                    Id = y.Id,
                    Qualification = y.Qualification,
                    PassedYear = y.PassedYear,
                    Marks = y.Marks,
                }).ToList();
                var result = await _baseRepository.Update<StudentModel>(Data);
                return result;
            }

            catch (Exception ex)
            {

                throw;
            }
        }

        //Delete a data...
        public async Task<int> PostDeleteData(StudentViewModel student)
        {
            try
            {
                StudentModel Data = await _baseRepository.GetAllData<StudentModel>().Where(x => x.StudentId == student.StudentId).FirstOrDefaultAsync();
                var result = await _baseRepository.Delete<StudentModel>(Data);
                return 1;
            }

            catch (Exception ex)
            {

                throw;
            }
        }
        //Upload a image 
        private string UploadedFile(StudentViewModel student)
        {
            string uniqueFileName = null;
            if(student.ProfileImage != null)
            {
                string uploadedFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + student.ProfileImage.FileName;
                string filePath = Path.Combine(uploadedFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    student.ProfileImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
        //Featch course list by faculty 
        public async Task<List<CourseViewModel>> GetCourseListByFacultyId(int Id)
        {
            var result = await _baseRepository.GetAllData<Course>().Where(x => x.FacultyId == Id).Select(y=>new CourseViewModel { 
            Id = y.Id,
            Name = y.Name
            }).ToListAsync();
            return result;
        }
    }
}
