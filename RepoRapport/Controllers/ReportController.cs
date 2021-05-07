using Intuit.Ipp.ReportService;
using Microsoft.AspNet.Identity;
using RepoRapport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RepoRapport.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        [Authorize]
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ReportService(userId);
            var model = service.GetReports();
            var model = new ReportListItem[0];
            return View(model);
        }
        //Add method here VVVV
        //GET
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create()
        {
            if (ModelState.IsValid)
            {

            }
            return View();
        }
    }
}