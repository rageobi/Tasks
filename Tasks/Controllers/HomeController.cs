using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Tasks.AuthenticationService;
using Tasks.Models;
using Tasks.Models.ViewModels;
using Tasks.Helpers;
namespace Tasks.Controllers
{
	[Authorize]
	public class HomeController : Controller
	{
		public IList<Task> Tasks = TasksHelper.Tasks;
		[HttpGet]
		public ActionResult Index()
		{
			if (Session["UserId"] != null)
			{
				return View(new TasksHelper().GetUserTasks((int)Session["UserId"]));
			}
            else
            {
				return RedirectToAction("Login", "Account");
            }
		}
		[HttpPost]
		public ActionResult Index(Task taskModel)
		{
			return View(taskModel);
		}

		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Task taskModel)
		{
			if (!ModelState.IsValid)
			{
				return View(taskModel);
			}
			else if(Session["UserId"] == null)
			{
				return RedirectToAction("Login","Account");
			}
			
			taskModel.CreatedOn = DateTime.Now;
			taskModel.LastUpdated = DateTime.Now;
			taskModel.IsCompleted = false;
			taskModel.UserId = (int)Session["UserId"];
			taskModel.TaskId = Task._TaskId++;
			Tasks.Add(taskModel);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public ActionResult Edit(int id)
		{
			if (Session["UserId"] != null)
            {
				if (Tasks.FirstOrDefault(x => x.TaskId == id).UserId == (int)Session["UserId"])
                {
					return View(new TasksHelper().GetTask(id));
				}
                else
                {
					TempData["UnauthorizedAlertMsg"] = "<script>alert('You are unauthorized for this.');</script>";
					return RedirectToAction("Index");
				}

			}
            else
            {
				return View("Index");
            }
			
			
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(Task taskModel)
		{
			if (!ModelState.IsValid)
			{
				return View(taskModel);
			}
			Tasks.FirstOrDefault(x => x.TaskId == taskModel.TaskId).TaskDescription =taskModel.TaskDescription;
			Tasks.FirstOrDefault(x => x.TaskId == taskModel.TaskId).LastUpdated = DateTime.Now;
			Tasks.FirstOrDefault(x => x.TaskId == taskModel.TaskId).IsCompleted=taskModel.IsCompleted;
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult Delete(int id)
        {
			if (Session["UserId"] != null)
			{
				if (Tasks.FirstOrDefault(x => x.TaskId == id).UserId == (int)Session["UserId"])
				{
					return View(new TasksHelper().GetTask(id));
				}
				else
				{
					TempData["UnauthorizedAlertMsg"] = "<script>alert('You are unauthorized for this.');</script>";
					return RedirectToAction("Index");
				}

			}
			else
			{
				return View("Index");
			}
        }
		[HttpPost]
		[ValidateAntiForgeryToken]
		[ActionName("Delete")]
		public ActionResult DeletePost(int id)
		{
			Tasks.Remove(Tasks.FirstOrDefault(x => x.TaskId == id));
			return RedirectToAction("Index");
		}
	}
}