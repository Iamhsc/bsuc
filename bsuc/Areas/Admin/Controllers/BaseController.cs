using bsuc.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bsuc.Areas.Admin.Controllers
{
    public abstract class BaseController : Controller
    {
        private BsucConnectext db = new BsucConnectext();
        public BsucConnectext DataContext { get { return db; } }
        public LayoutView lay;
        public BaseController()
        {
           // ViewBag.adminmenu = DataContext.bmenu.ToList();
            lay=new LayoutView(DataContext);
            ViewBag.adminmenu = lay.topmenu;
            ViewBag.secondmenu = lay.arrls;
        }
    }
}
