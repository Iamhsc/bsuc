using bsuc.common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bsuc.Areas.Admin.Controllers
{
    public class ArticleController : BaseController
    {
        private BsucConnectext db = new BsucConnectext();

        public ActionResult Index()
        {
            List<Bsuc_Protal_Post> post = db.bsuc_protal_post.ToList();
            return View(post);
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }

    }
}
