using bsuc.common;
using bsuc.common.Model;
using Newtonsoft.Json;
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
            ViewBag.cate = db.bsuc_protal_category.ToList();
            ViewBag.tag = db.bsuc_protal_tag.ToList();
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddPost(Bsuc_Protal_Post posts) {
            posts.tags =Request.Form["tags"];
            posts.published_time = Common.GetTimeStamp();
            db.bsuc_protal_post.Add(posts);
            db.SaveChanges();
            return View("Index");
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
