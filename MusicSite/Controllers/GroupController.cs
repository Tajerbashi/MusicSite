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
    public class GroupController : Controller
    {
        DbContexts DB = new DbContexts();
        IGroupRepository groupRepository;
        public GroupController()
        {
            groupRepository = new GroupRepository(DB);
        }
        // GET: Group
        [Route("Group/Index")]
        public ActionResult Index()
        {
            return PartialView(groupRepository.GetAllGroupToShow());
        }
    }
}