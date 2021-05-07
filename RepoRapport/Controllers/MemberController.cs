using Microsoft.AspNet.Identity;
using RepoRapport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RepoRapport.Controllers
{
    public class MemberController : Controller
    {
        // GET: Member
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MemberService(userId);
            var model = service.GetReports();
            var model = new MemberListItem[0];
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