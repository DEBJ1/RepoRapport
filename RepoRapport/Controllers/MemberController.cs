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
            var model = new MemberListItem[0];
            return View(model);
        }
        //Add method here VVVV
        //GET
        public ActionResult Create()
        {
            return View();
        }
    }
}