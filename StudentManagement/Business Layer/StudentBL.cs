using Microsoft.AspNetCore.Hosting;
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
        public StudentViewModel GetData(int Id)
        {
            var studentdata = _baseRepository.GetAllData<StudentModel>().Where(x => x.StudentId == Id).Select(x => new StudentViewModel
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
                FacultyName = x.Faculties.FacultyName,
            }).FirstOrDefault();
            studentdata.CourseList = _baseRepository.GetAllData<Course>().ToList();
            studentdata.FacultyList = _baseRepository.GetAllData<FacultyModel>().ToList();
            studentdata.CourseName = studentdata.CourseList.Where(y => y.Id == studentdata.CourseId).Select(z => z.Name).FirstOrDefault();
            return studentdata;
        }

        //Show a data in index page......
        public List<StudentViewModel> GetIndexData()
        {
            var std = _baseRepository.GetAllData<StudentModel>().Select(x => new StudentViewModel
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
            }).OrderByDescending(z => z.StudentId).ToList();
            return std;
        }

        //Create a data..
        public StudentViewModel GetCreateData()
        {
            StudentViewModel studentModel = new StudentViewModel();
            studentModel.CourseList = _baseRepository.GetAllData<Course>().ToList();
            studentModel.FacultyList = _baseRepository.GetAllData<FacultyModel>().ToList();
            return studentModel;
        }

        public int PostCreateData(StudentViewModel student)
        {
             try
            {
                string uniqueFileName = UploadedFile(student);
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
                var result = _baseRepository.Create<StudentModel>(model);
                
                return 1;
            }

            catch (Exception ex)
            {

                throw;
            }
        }

        //Edit a data....
        public int PostEditData(StudentViewModel student)
        {
            try
            {
                //string uniqueFileName = UploadedFile(student);
                StudentModel Data = _baseRepository.GetAllData<StudentModel>().Where(x => x.StudentId == student.StudentId).FirstOrDefault();
                Data.FirstName = student.FirstName;
                Data.MidName = student.MidName;
                Data.LastName = student.LastName;
                Data.Address = student.Address;
                Data.JoinDate = student.JoinDate;
                Data.Gender = student.Gender;
                Data.IsActive = student.IsActive;
                Data.FacultyId = student.FacultyId;
                Data.CourseId = student.CourseId;
                //Data.ProfilePicture = uniqueFileName;
                var result = _baseRepository.Update<StudentModel>(Data);
                return 1;
            }

            catch (Exception ex)
            {

                throw;
            }
        }

        //Delete a data...
        public int PostDeleteData(StudentViewModel student)
        {
            try
            {
                StudentModel Data = _baseRepository.GetAllData<StudentModel>().Where(x => x.StudentId == student.StudentId).FirstOrDefault();
                var result = _baseRepository.Delete<StudentModel>(Data);
                return 1;
            }

            catch (Exception ex)
            {

                throw;
            }
        }

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
    }
}
