using bsuc.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bsuc.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        private BsucConnectext db = new BsucConnectext();
        public BsucConnectext DataContext { get { return db; } }
        //
        // GET: /Admin/Base/

        public BaseController()
        {
            ViewData["admin_menu"] = from c in DataContext.bmenu.Select(t=>new{t.title,t.url,t.id})
                                     select c;
        }

    }
}
