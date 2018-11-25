using bsuc.common.Model;
using System.Web.Mvc;

namespace bsuc.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        private BsucConnectext db=new BsucConnectext();

        public ActionResult Index()
        {
            ViewBag.Title = "后台首页";
            return View();
        }
    }
}
