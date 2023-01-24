using DAL.Context;
using DAL.Repository;
using DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicSite.Controllers
{
    public class SectionController : Controller
    {
        DbContexts DB=new DbContexts();
        IGroupRepository groupRepository;

        // GET: Section
        public SectionController()
        {
            groupRepository = new GroupRepository(DB);
        }
        public ActionResult Group()
        {
            return PartialView(groupRepository.GetAllGroupToShow());
        }
    }
}