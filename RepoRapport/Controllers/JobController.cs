using Microsoft.AspNet.Identity;
using RepoRapport.Models;
using RepoRapport.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RepoRapport.Controllers
{[Authorize]
    public class JobController : Controller
    {
        // GET: Job

        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new JobServices(userId);
            var model = service.GetJobs();

            return View(model);
        }

        //GET: JOb/Create
        public ActionResult Create()
        {
            return View();
        }


        //POST: job/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JobCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateJobService();

            if (service.CreateJob(model))
            {
                TempData["SaveResult"] = "Your Job was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Job could not be created.");

            return View(model);
        }

        //GET: Job/Details/{id}
        public ActionResult Details(int id)
        {
            var svc = CreateJobService();
            var model = svc.GetJobById(id);

            return View(model);
        }

        //GET: Job/Edit/{id}
        public ActionResult Edit(int id)
        {
            var service = CreateJobService();
            var detail = service.GetJobById(id);
            var model =
                new JobEdit
                {
                    Title = detail.Title,
                    Description = detail.Description,
                    Completed = detail.Completed
                };
            return View(model);
        }

        //POST: Job/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, JobEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.JobID != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreateJobService();

            if (service.UpdateJob(model))
            {
                TempData["SaveResult"] = "Your Job was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Job could not be updated.");
            return View(model);
        }

        //GET: Job/Delete/{id}
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateJobService();
            var model = svc.GetJobById(id);

            return View(model);
        }

        //POST: Job/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateJobService();

            service.DeleteJob(id);

            TempData["SaveResult"] = "Your Job was deleted";

            return RedirectToAction("Index");
        }

        //Helper Method
        private JobServices CreateJobService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new JobServices(userId);
            return service;
        }
    }
}