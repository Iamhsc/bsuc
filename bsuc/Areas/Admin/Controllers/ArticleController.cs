using bsuc.common;
using bsuc.common.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
            List<Bsuc_Protal_Post> post = db.bsuc_protal_post.OrderByDescending(p=>p.id).ToList();
            return View(post);
        }

        public ActionResult Add()
        {
            ViewBag.cate = db.bsuc_protal_category.ToList();
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public object AddPost(Bsuc_Protal_Post posts)
        {
            posts.published_time = Common.GetTimeStamp();
            db.bsuc_protal_post.Add(posts);
            db.SaveChanges();
            JObject obj = new JObject();
            obj["code"] = 1;
            obj["msg"] = "添加成功";
            obj["url"] = "/admin/article";
            return obj;
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
