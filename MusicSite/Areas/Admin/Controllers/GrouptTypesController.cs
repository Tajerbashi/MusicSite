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
using DAL.Repository;
using DAL.Services;

namespace MusicSite.Areas.Admin.Controllers
{
    public class GrouptTypesController : Controller
    {
        IGroupRepository groupRepository;
        private DbContexts db = new DbContexts();
        public GrouptTypesController()
        {
            groupRepository = new GroupRepository(db);
        }
        // GET: Admin/GrouptTypes
        public ActionResult Index()
        {
            return View(groupRepository.GetAll());
        }

        // GET: Admin/GrouptTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrouptType grouptType = groupRepository.GetById(id.Value);
            if (grouptType == null)
            {
                return HttpNotFound();
            }
            return PartialView(grouptType);
        }

        // GET: Admin/GrouptTypes/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Admin/GrouptTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GroupId,groupName,visit,duration,CreateDate,Type")] GrouptType grouptType)
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

        // GET: Admin/GrouptTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrouptType grouptType = groupRepository.GetById(id.Value);
            if (grouptType == null)
            {
                return HttpNotFound();
            }
            return PartialView(grouptType);
        }

        // POST: Admin/GrouptTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GroupId,groupName,Type")] GrouptType grouptType)
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

        // GET: Admin/GrouptTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrouptType grouptType = groupRepository.GetById(id.Value);
            if (grouptType == null)
            {
                return HttpNotFound();
            }
            return PartialView(grouptType);
        }

        // POST: Admin/GrouptTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GrouptType grouptType = groupRepository.GetById(id);
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
