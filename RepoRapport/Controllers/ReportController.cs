using Intuit.Ipp.ReportService;
using Microsoft.AspNet.Identity;
using RepoRapport.Models;
using RepoRapport.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RepoRapport.Controllers
{
    [Authorize]
    public class ReportController : Controller
    {
        // GET: Report
      
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ReportServices(userId);
            var model = service.GetReports();

            return View(model);
        }

        //GET: Report/Create
        public ActionResult Create()
        {
            return View();
        }


        //POST: REport/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReportCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateReportService();

            if (service.CreateReport(model))
            {
                TempData["SaveResult"] = "Your Report was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Report could not be created.");

            return View(model);
        }

        //GET: Report/Details/{id}
        public ActionResult Details(int id)
        {
            var svc = CreateReportService();
            var model = svc.GetReportById(id);

            return View(model);
        }

        //GET: Report/Edit/{id}
        public ActionResult Edit(int id)
        {
            var service = CreateReportService();
            var detail = service.GetReportById(id);
            var model =
                new ReportEdit
                {
                    Title = detail.Title,
                    Content = detail.Content
                };
            return View(model);
        }

        //POST: Report/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ReportEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ReportID != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreateReportService();

            if (service.UpdateReport(model))
            {
                TempData["SaveResult"] = "Your Report was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Report could not be updated.");
            return View(model);
        }

        //GET: Report/Delete/{id}
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateReportService();
            var model = svc.GetReportById(id);

            return View(model);
        }

        //POST: Report/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateReportService();

            service.DeleteReport(id);

            TempData["SaveResult"] = "Your Report was deleted";

            return RedirectToAction("Index");
        }

        //Helper Method
        private ReportServices CreateReportService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ReportServices(userId);
            return service;
        }
    }
}
