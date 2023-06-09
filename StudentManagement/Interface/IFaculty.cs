﻿using StudentManagement.Models;
using StudentManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Interface
{
    public interface IFaculty
    {
        Task<FacultyModel> PostCreateData(FacultyViewModel faculty);
    }
}
