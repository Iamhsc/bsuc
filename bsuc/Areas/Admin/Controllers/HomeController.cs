using bsuc.Areas.Admin.Models;
using System.Web.Mvc;

namespace bsuc.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        private BsucConnectext db=new BsucConnectext();
        public ActionResult Index()
        {
            return View();
        }
    }
}
