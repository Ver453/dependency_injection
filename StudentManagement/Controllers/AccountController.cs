using Microsoft.AspNetCore.Mvc;
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
    public class AccountController:BaseController
    {
        private readonly IAccount _account;
        public AccountController(IAccount account)
        {
            _account = account;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserRegistrationViewModel usrRegister)
        {
            if (ModelState.IsValid)
            {
                var IsExists = _account.IsEmailExists(usrRegister.Email);
                if (IsExists)
                {
                    ModelState.AddModelError("EmailExists", "Email Already Exist");
                    return View();
                }
                var data = await _account.UserRegister(usrRegister);
                TempData["ResultOk"] = "User Register sucessfully!";
                return View();
                //return Json(new DataResult { ResultType = ResultType.Success, Message = "Success" });
            }
            return Json(new DataResult { ResultType = ResultType.Failed, Message = "Failed" });
        }


        [HttpGet]
        public IActionResult UserVerify()
        {
            return View();
        }
        public IActionResult UserVerification(string id)
        {
            _account.UserVerification(id);
            ViewBag.Message = "Email Verification completed";
            return RedirectToAction("UserVerify","Account");
        }
        [HttpGet]
        public IActionResult UserLogin()
        {
            return View();
        }
    }
}
