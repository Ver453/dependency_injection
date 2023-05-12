using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Business_Layer.Repository;
using StudentManagement.Interface;
using StudentManagement.Models;
using StudentManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Business_Layer
{
    public class AccountBL : IAccount
    {
        private readonly IBaseRepository _baseRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public object ViewBag { get; private set; }

        public AccountBL(IHttpContextAccessor httpContextAccessor,IBaseRepository baseRepository, IWebHostEnvironment webHostEnvironment)
        {
            _httpContextAccessor = httpContextAccessor;
            _baseRepository = baseRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<UserRegistration> UserRegister(UserRegistrationViewModel usrRegister)
        {
            try
            {
                var usrModel = new UserRegistration
                {
                    Id = usrRegister.Id,
                    FirstName = usrRegister.FirstName,
                    LastName = usrRegister.LastName,
                    Email = usrRegister.Email,
                    OTP = usrRegister.OTP,
                    EmailVerification = usrRegister.EmailVerification = false,
                    ActivetionCode = usrRegister.ActivetionCode = Guid.NewGuid(),
                    Password = usrRegister.Password = textToEncrypt(usrRegister.Password.ToString())
                };
                var result = await _baseRepository.Add<UserRegistration>(usrModel);
                SendEmailToUser(usrModel);
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

        public void SendEmailToUser(UserRegistration userData)
        {
            var GenarateUserVerificationLink = "/Account/UserVerification/" + userData.ActivetionCode;
            //var link = Request.Url.Replace(Request.Url.PathAndQuery, GenarateUserVerificationLink);
            //var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, GenarateUserVerificationLink);
            //var link = (userData.Id, userData.ActivetionCode) + GenarateUserVerificationLink;

            var currentUrl = new Uri($"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}{_httpContextAccessor.HttpContext.Request.Path}{_httpContextAccessor.HttpContext.Request.QueryString}");
            var link = new Uri(currentUrl, GenarateUserVerificationLink);
            var fromMail = new MailAddress("sagaradk009@gmail.com", "Sagar"); // set your email    
            var fromEmailpassword = "xanggsrqipbehifz"; // Set your password     
            var toEmail = new MailAddress(userData.Email);

            var smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(fromMail.Address, fromEmailpassword);

            var Message = new MailMessage(fromMail, toEmail);
            Message.Subject = "Registration Completed-Demo";
            Message.Body = "<br/> Your registration completed succesfully." +
                           "<br/> please click on the below link for account verification" +
                           "<br/><br/><a href=" + link + ">" + link + "</a>";
            Message.IsBodyHtml = true;
            smtp.Send(Message);
        }


        public bool UserVerification(string activatecode)
        {
            bool Status = false;

            //_baseRepository.Configuration.ValidateOnSaveEnabled = false; // Ignor to password confirmation     
            var IsVerify = _baseRepository.GetAllData<UserRegistration>().Where(u => u.ActivetionCode == new Guid(activatecode)).FirstOrDefault();

            if (IsVerify != null)
            {
                IsVerify.EmailVerification = true;
                _baseRepository.Update(IsVerify);
                //_baseRepository.SaveChanges();
                Status = true;
            }
            else
            {
               Status = false;
            }
            return IsVerify != null;
        }


    }
}
