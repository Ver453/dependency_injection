using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Business_Layer.Repository;
using StudentManagement.Interface;
using StudentManagement.Models;
using StudentManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Business_Layer
{
    public class AccountBL : IAccount
    {
        private readonly IBaseRepository _baseRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AccountBL(IBaseRepository baseRepository, IWebHostEnvironment webHostEnvironment)
        {
            _baseRepository = baseRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<UserRegistration> UserRegister(UserRegistrationViewModel usrRegister)
        {
            try
            {
                var usrModel = new UserRegistration
                {
                    FirstName = usrRegister.FirstName,
                    LastName = usrRegister.LastName,
                    Email = usrRegister.Email,
                    OTP = usrRegister.OTP,
                    EmailVerification = usrRegister.EmailVerification = false,
                    ActivetionCode = usrRegister.ActivetionCode = Guid.NewGuid(),
                    Password = usrRegister.Password = textToEncrypt(usrRegister.Password.ToString())
                };
                var result = await _baseRepository.Add<UserRegistration>(usrModel);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private static string textToEncrypt(string Password)
        {
            return Convert.ToBase64String(System.Security.Cryptography.SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(Password)));
        }

        public bool IsEmailExists(string eMail)
        {
            var IsCheck = _baseRepository.GetAllData<UserRegistration>().Where(email => email.Email == eMail).FirstOrDefault();
            return IsCheck != null;
        }
    }
}
