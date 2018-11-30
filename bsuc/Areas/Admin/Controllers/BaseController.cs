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
            base.OnActionExecuted(filterContext);
            if (Session["user_id"] != null && Session["user_type"] != null)
            {
                int uid = Convert.ToInt32(Session["user_id"]);
                int rid = Convert.ToInt32(Session["user_type"]);
                if (uid != 1 || rid != 1)
                {
                    var u = Request.Url.AbsolutePath.ToLower();
                    var thismenu = db.bmenu.Where(m => m.url == u);
                    if (thismenu.Count() > 0)
                    {
                        int id = thismenu.First().id;//当前节点id
                        int role = Convert.ToInt32(Session["user_type"]);
                        string auth = db.bsuc_role.First(r => r.id == role).auth;
                        string[] arrauth = auth.Split(',');
                        int in1 = Array.IndexOf(arrauth, id.ToString());
                        if (in1 == -1)
                        {
                            var requ = Request.UrlReferrer.AbsolutePath;
                            //没有权限
                            filterContext.RequestContext.HttpContext.Response.Write("<script>alert('[" + thismenu.First().title+ "]权限不足');location.href='" + requ + "'</script>");
                            filterContext.RequestContext.HttpContext.Response.End();
                        }
                    }
                }
            }
            else
            {
                filterContext.Result = Redirect("/admin/public/login");
            }
        }

        public BaseController()
        {
            lay = new LayoutView(DataContext);
            ViewBag.modulemenu = lay.modulemenu;
            ViewBag.topmenu = lay.topmenu;
        }
    }
}
