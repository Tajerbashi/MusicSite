using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using DAL.Context;

namespace MusicSite.Areas.Admin.Controllers
{
    [Authorize]

    public class GroupController : Controller
    {
        IGroupRepository groupRepository;
        private DbContexts db = new DbContexts();
        public GroupController()
        {
            groupRepository = new GroupRepository(db);
        }
        // GET: Admin/Group
        public ActionResult Index()
        {
            return View(groupRepository.GetAll());
        }

        // GET: Admin/Group/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group grouptType = groupRepository.GetById(id.Value);
            if (grouptType == null)
            {
                return HttpNotFound();
            }
            return PartialView(grouptType);
        }

        // GET: Admin/Group/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Admin/Group/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GroupId,GroupName,Visit,CreateDate")] Group grouptType)
        {
            if (ModelState.IsValid)
            {
                grouptType.CreateDate = DateTime.Now;
                groupRepository.Add(grouptType);
                groupRepository.Save();
                return RedirectToAction("Index");
            }

            return PartialView(grouptType);
        }

        // GET: Admin/Group/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group grouptType = groupRepository.GetById(id.Value);
            if (grouptType == null)
            {
                return HttpNotFound();
            }
            return PartialView(grouptType);
        }

        // POST: Admin/Group/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GroupId,GroupName")] Group grouptType)
        {
            if (ModelState.IsValid)
            {
                grouptType.CreateDate = DateTime.Now;
                groupRepository.Update(grouptType);
                groupRepository.Save();
                return RedirectToAction("Index");
            }
            return PartialView(grouptType);
        }

        // GET: Admin/Group/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group grouptType = groupRepository.GetById(id.Value);
            if (grouptType == null)
            {
                return HttpNotFound();
            }
            return PartialView(grouptType);
        }

        // POST: Admin/Group/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Group grouptType = groupRepository.GetById(id);
            groupRepository.Delete(grouptType);
            groupRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
