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

        /// <summary>
        /// 再控制器执行方法之前执行 验证登陆
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Session["user_id"] =1;
            Session["user_name"] = "admin";
            base.OnActionExecuted(filterContext);
            if (Session["user_id"] == null)
            {
                filterContext.Result = Redirect("/admin/public/login");
            }
        }

        public BaseController()
        {
            // ViewBag.adminmenu = DataContext.bmenu.ToList();
            lay = new LayoutView(DataContext);
            ViewBag.modulemenu = lay.modulemenu;
            ViewBag.topmenu = lay.topmenu;
        }
    }
}
