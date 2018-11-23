using bsuc.common;
using bsuc.common.Model;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace bsuc.Areas.Admin.Controllers
{
    public class ArticleController : BaseController
    {
        private BsucConnectext db = new BsucConnectext();

        public ActionResult Index()
        {
            string url=Request.RawUrl;
            int id=db.bmenu.First(m => m.url== url).id;
            ViewBag.id = id;
            ViewBag.Title = "文章列表";
            List<Bsuc_Protal_Post> post = db.bsuc_protal_post.OrderByDescending(p=>p.id).ToList();
            return View(post);
        }

        public ActionResult Add()
        {
            ViewBag.Title = "文章添加";
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

        public ActionResult Edit(int id=0)
        {
            Bsuc_Protal_Post post = db.bsuc_protal_post.Find(id);
            if (post==null)
            {
                return HttpNotFound();
            }
            ViewBag.Title = "文章编辑";
            ViewBag.cate = db.bsuc_protal_category.ToList();
            ViewBag.postInfo = post;
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public object EditPost(Bsuc_Protal_Post post)
        {
            post.published_time = Common.GetTimeStamp();
            db.Entry(post).State = EntityState.Modified;
            db.SaveChanges();
            JObject obj = new JObject();
            obj["code"] = 1;
            obj["msg"] = "文章修改成功";
            obj["url"] = "/admin/article";
            return obj;
        }

       
        public object Delete(int id)
        {
            Bsuc_Protal_Post post = db.bsuc_protal_post.Find(id);
            db.bsuc_protal_post.Remove(post);
            db.SaveChanges();
            JObject obj = new JObject();
            obj["code"] = 1;
            obj["msg"] = "删除成功";
            return obj;
        }


        public ActionResult Details(int id)
        {
            Bsuc_Protal_Post post = db.bsuc_protal_post.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            ViewBag.Title = "文章详情";
            ViewBag.De = Common.IntToDateTime(post.published_time, "yyyy-MM-dd HH:mm:ss");
            ViewBag.author = db.buser.Find(post.user_id).nickname;
            ViewBag.catename = db.bsuc_protal_category.First(c=>c.id==post.cates).catname;
            return View(post);
        }
    }
}
