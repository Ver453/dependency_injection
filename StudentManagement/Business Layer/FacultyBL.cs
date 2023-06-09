﻿using StudentManagement.Business_Layer.Repository;
using StudentManagement.Interface;
using StudentManagement.Models;
using StudentManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Business_Layer
{
    public class FacultyBL:IFaculty
    {
        private readonly IBaseRepository _baseRepository;


        public FacultyBL(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public async Task<FacultyModel> PostCreateData(FacultyViewModel faculty)
        {
            try
            {
                var model = new FacultyModel
                {
                    FacultyName = faculty.FacultyName
                };
                var result = await _baseRepository.Create<FacultyModel>(model);

                return model;
            }

            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
