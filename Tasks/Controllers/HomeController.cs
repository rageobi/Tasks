using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Tasks.AuthenticationService;
using Tasks.Models;
using Tasks.Models.ViewModels;

namespace Tasks.Controllers
{
	[Authorize]
	public class HomeController : Controller

	{
		[AllowAnonymous]
		[HttpGet]
        public ActionResult Login() 
		{
			return View();
		}

		public ActionResult Index()
		{
			return View();
		}

		public void SignOut()
		{
			
		}

	}
}