using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicSite.Controllers
{
    public class HeaderController : Controller
    {
        // GET: Header
        public ActionResult LoginPanelUser()
        {
            return PartialView();
        }
        public ActionResult SearchPanel()
        {
            return PartialView();
        }
    }
}