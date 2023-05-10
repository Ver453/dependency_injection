using Microsoft.AspNetCore.Mvc;
using StudentManagement.Models;
using StudentManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Interface
{
    public interface IAccount
    {
        Task<UserRegistration> UserRegister(UserRegistrationViewModel usrRegister);
        bool IsEmailExists(string eMail);
        //Task<IActionResult> IsEmailExists(string email);
    }
}
