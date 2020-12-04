using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Tasks.AuthenticationService;
using Tasks.Helpers;
using Tasks.Models;
using Tasks.Models.ViewModels;
using Tasks.ViewModels;

namespace Tasks.Controllers
{
    public class AccountController : Controller
    {
        private static IList<User> Users = TasksHelper.Users;
   
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
                User MatchedUser = Users.FirstOrDefault(x => x.Username.Equals(loginViewModel.UserName));
                if (MatchedUser != null)
                {   
                    FormsAuthentication.SetAuthCookie(MatchedUser.Username, true);
                    Session["UserId"] = new TasksHelper().GetUserID(MatchedUser.Username);
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
            Users.Add(new User()
            {
                FirstName = "Testing",
                LastName = "TLN",
                Email = "a@a.com",
                Username = "test",
                Password = "asdfghjkl",
                CreationDate = DateTime.Now,
                UserId = Models.User._UserId++
            });
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
            else if (Users.Any(item => item.Username == registerViewModel.UserName))
            {
                TempData["msg"] = "<script>alert('Already an user. Please change your username');</script>";
                return View(registerViewModel);
            }
            Users.Add(new User()
            {
                FirstName = registerViewModel.FirstName,
                LastName = registerViewModel.LastName,
                Email = registerViewModel.Email,
                Username = registerViewModel.UserName,
                Password = registerViewModel.Password,
                CreationDate = registerViewModel.CreationDate
            });

            return RedirectToAction("Login", "Account");
        }
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}