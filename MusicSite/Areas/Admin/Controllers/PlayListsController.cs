using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using DAL.Context;
using DAL.Repository;
using DAL.Services;
using Microsoft.Ajax.Utilities;

namespace MusicSite.Areas.Admin.Controllers
{
    public class PlayListsController : Controller
    {
        IPlayListRepository PlayList;
        IGroupRepository Group;
        ISongRepository Songs;
        private DbContexts DB=new DbContexts();
        public PlayListsController()
        {
            PlayList= new PlayListRepository(DB);
            Group= new GroupRepository(DB);
            Songs = new SongRepository(DB);
        }

        // GET: Admin/PlayLists
        public ActionResult Index()
        {
            return View(PlayList.GetGroups());
        }

        // GET: Admin/PlayLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayList playList = PlayList.GetById(id.Value);
            if (playList == null)
            {
                return HttpNotFound();
            }
            return PartialView(playList);
        }

        // GET: Admin/PlayLists/Create
        public ActionResult Create()
        {
            ViewBag.GroupId = new SelectList(Group.GetAll(), "GroupId", "groupName");
            return PartialView();
        }

        // POST: Admin/PlayLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "playListId,GroupId,Name,Description,PlayCount,CreateDate,Type")] PlayList playList)
        {
            if (ModelState.IsValid)
            {
                playList.CreateDate= DateTime.Now;
                playList.PlayCount= 0;

                PlayList.Add(playList);
                PlayList.Save();
                return RedirectToAction("Index");
            }

            //ViewBag.GroupId = new SelectList(db.GrouptTypes, "GroupId", "groupName", playList.GroupId);
            ViewBag.GroupId = new SelectList(Group.GetAll(), "GroupId", "groupName");
            return PartialView(playList);
        }

        // GET: Admin/PlayLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayList playList = PlayList.GetById(id.Value);
            if (playList == null)
            {
                return HttpNotFound();
            }
            //ViewBag.GroupId = new SelectList(db.GrouptTypes, "GroupId", "groupName", playList.GroupId);
            ViewBag.GroupId = new SelectList(Group.GetAll(), "GroupId", "groupName");
            return PartialView(playList);
        }

        // POST: Admin/PlayLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "playListId,GroupId,Name,Description,PlayCount,CreateDate,Type")] PlayList playList)
        {
            if (ModelState.IsValid)
            {
                playList.CreateDate = DateTime.Now;
                playList.PlayCount = 0;
                PlayList.Update(playList);
                PlayList.Save();
                return RedirectToAction("Index");
            }
            //ViewBag.GroupId = new SelectList(db.GrouptTypes, "GroupId", "groupName", playList.GroupId);
            ViewBag.GroupId = new SelectList(Group.GetAll(), "GroupId", "groupName");
            return PartialView(playList);
        }

        // GET: Admin/PlayLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayList playList =PlayList.GetById(id.Value);
            if (playList == null)
            {
                return HttpNotFound();
            }
            return PartialView(playList);
        }

        // POST: Admin/PlayLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlayList playList = PlayList.GetById(id);
            PlayList.Delete(playList);
            PlayList.Save();
            return RedirectToAction("Index");
        }
        
        public ActionResult CreatePlayListSongs()
        {
            ViewBag.Groups = Group.GetAll();
            ViewBag.Songs = Songs.GetAll();
            ViewBag.PlayLists = PlayList.GetAll();
            return View();
        }
        [HttpPost]
        public void CreatePlayListSongs(string PlayListId, List<string> SongIdList)
        {
            PlayList playList = PlayList.GetById(Int32.Parse(PlayListId));
            foreach (var i in SongIdList)
            {
                Song song = Songs.GetById(Convert.ToInt32(i));
                song.PlayLists = playList;
            }
            Songs.Save();
            PlayList.Save();
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                DB.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
