using bsuc.common.Model;
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
            if (Session["user_id"] == null)
            {
                Response.Redirect("/admin/public/login");
                //Response.Write("<script>location.href=''</script>");
               return;
            }
            // ViewBag.adminmenu = DataContext.bmenu.ToList();
            lay = new LayoutView(DataContext);
            ViewBag.modulemenu = lay.modulemenu;
            ViewBag.topmenu = lay.topmenu;
        }
    }
}
