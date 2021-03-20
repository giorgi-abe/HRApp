using HRApplicationMVC.Models;
using HRApplicationMVC.Services;
using HRApplicationMVC.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRApplicationMVC.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromServices] ApiUserService _apiUserService, User user)
        {
            var data = await _apiUserService.PostAsync(user);
            if(data == null)
            {
                return RedirectToAction("ExistInfo");
            }
            return RedirectToAction("List", "Employee");
        }
        public IActionResult ExistInfo()
        {
            TempData["alertMessage"] = "This accound already exist";
            return RedirectToAction("Register");
        }
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LogIn([FromServices] ApiAuthService _apiLogInService, AuthDto data)
        {
            var Token = await _apiLogInService.PostAsync(data);
            if (Token != null)
            {
                var SignedIn = new SignedInDto
                {
                    Token = Token,
                    Username = data.Username,
                };
                await LoginUserHelperManager.LoginUser(SignedIn);
            }
            else
            {
               return RedirectToAction("WrongLogIn");
            }

            return RedirectToAction("List", "Employee");
        }
        public IActionResult WrongLogIn()
        {
            TempData["alertMessage"] = "Wrong Username or Password";
            return RedirectToAction("LogIn");
        }
        public async Task<IActionResult> LogOut()
        {
            await LoginUserHelperManager.LogOutUser();
            return RedirectToAction("Login", "User", null);
        }
    }
}
