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
    public class MemberController : Controller
    {
        // GET: Member

        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MemberServices(userId);
            var model = service.GetMembers();

            return View(model);
        }

        //GET: Member/Create
        public ActionResult Create()
        {
            return View();
        }


        //POST: member/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MemberCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateMemberService();

            if (service.CreateMember(model))
            {
                TempData["SaveResult"] = "Your Member was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Member could not be created.");

            return View(model);
        }

        //GET: Member/Details/{id}
        public ActionResult Details(int id)
        {
            var svc = CreateMemberService();
            var model = svc.GetMemberById(id);

            return View(model);
        }

        //GET: member/Edit/{id}
        public ActionResult Edit(int id)
        {
            var service = CreateMemberService();
            var detail = service.GetMemberById(id);
            var model =
                new MemberEdit
                {
                    Title = detail.Title,
                    Name = detail.Name,
                    Skillset = detail.Skillset
                };
            return View(model);
        }

        //POST: Member/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MemberEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.MemberID != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreateMemberService();

            if (service.UpdateMember(model))
            {
                TempData["SaveResult"] = "Your Member was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Member could not be updated.");
            return View(model);
        }

        //GET: Member/Delete/{id}
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateMemberService();
            var model = svc.GetMemberById(id);

            return View(model);
        }

        //POST: Member/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateMemberService();

            service.DeleteMember(id);

            TempData["SaveResult"] = "Your Member was deleted";

            return RedirectToAction("Index");
        }

        //Helper Method
        private MemberServices CreateMemberService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MemberServices(userId);
            return service;
        }
    }
}