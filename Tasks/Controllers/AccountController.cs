using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Tasks.AuthenticationService;
using Tasks.Models;
using Tasks.Models.ViewModels;
using Tasks.ViewModels;

namespace Tasks.Controllers
{
    public class AccountController : Controller
    {
        private IList<User> Users = CustomMemberShipProvider.Users;
        public AuthenticationService.AuthenticationService authenticationService;

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }
            if (new CustomMemberShipProvider().ValidateUser(loginViewModel.UserName, loginViewModel.Password))
            {
                User MatchedUser = Users.FirstOrDefault(x => x.UserName.Equals(loginViewModel.UserName));
                if (MatchedUser != null)
                {
                    FormsAuthentication.SetAuthCookie(MatchedUser.UserName, true);
                }
                else
                {
                    TempData["msg"] = "<script>alert('No user found please register');</script>";
                    return RedirectToAction("Register");
                }
            }
            return RedirectToAction("Index", "Home");

        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerViewModel);
            }
            else if (Users.Any(item => item.UserName == registerViewModel.UserName && item.Email == registerViewModel.Email))
            {
                return View(registerViewModel);
            }
            Users.Add(new User()
            {
                FirstName = registerViewModel.FirstName,
                LastName = registerViewModel.LastName,
                Email = registerViewModel.Email,
                UserName = registerViewModel.UserName,
                Password = registerViewModel.Password,
                CreationDate = registerViewModel.CreationDate
            });

            return RedirectToAction("Login", "Account");
        }
        public void Logout()
        {
            FormsAuthentication.SignOut();
        }
    }
}