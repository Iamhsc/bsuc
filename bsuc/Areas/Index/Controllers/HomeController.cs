using bsuc.common;
using bsuc.common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace bsuc.Areas.Index.Controllers
{
    public class HomeController : Controller
    {
        private BsucConnectext db = new BsucConnectext();

        /// <summary>
        /// 官网首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.Title = "欢迎光临百色学院官网";
            //获取文章类别为1（学校要闻）的文章；
            ViewBag.news = db.bsuc_protal_post.Where(p => p.cates == 1 && p.post_status==1&&p.delete_time==0).Take(10).OrderByDescending(p=>p.id).ToList();
            //获取文章类别为2（通知公告）的文章;
            ViewBag.newa = db.bsuc_protal_post.Where(p => p.cates == 2 && p.post_status == 1 && p.delete_time == 0).Take(8).OrderByDescending(p => p.id).ToList();
            //获取文章类别为3（招标信息）的文章;
            ViewBag.newb = db.bsuc_protal_post.Where(p => p.cates == 3 && p.post_status == 1 && p.delete_time == 0).Take(8).OrderByDescending(p => p.id).ToList();
            //获取文章类别为4（部门动态）的文章
            ViewBag.bmdt = db.bsuc_protal_post.Where(p => p.cates == 4 && p.post_status == 1 && p.delete_time == 0).Take(8).OrderByDescending(p => p.id).ToList();
            //获取文章类别为5（部门动态）的文章
            ViewBag.ztbd = db.bsuc_protal_post.Where(p => p.cates == 5 && p.post_status == 1 && p.delete_time == 0).Take(8).OrderByDescending(p => p.id).ToList();
            //获取文章类别为6（百院媒体）的文章
            ViewBag.bymt = db.bsuc_protal_post.Where(p => p.cates == 6 && p.post_status == 1 && p.delete_time == 0).Take(8).OrderByDescending(p => p.id).ToList();
            //获取文章类别为7（科学研究）的文章
            ViewBag.kxyj = db.bsuc_protal_post.Where(p => p.cates == 7 && p.post_status == 1 && p.delete_time == 0).Take(8).OrderByDescending(p => p.id).ToList();
            return View();
        }



        /// <summary>
        /// 学校概况
        /// </summary>
        /// <returns></returns>
        public ActionResult xxgk()
        {
            ViewBag.Title = "欢迎光临百色学院官网";
       
            return View();
        }


        /// <summary>
        /// 组织结构
        /// </summary>
        /// <returns></returns>
        public ActionResult zzjg()
        {  
            return View();
        }

        /// <summary>
        /// 科学研究
        /// </summary>
        /// <returns></returns>
        public ActionResult kxyj()
        {
            ViewBag.Title = "欢迎光临百色学院官网";

            return View();
        }

        /// <summary>
        /// 校园风光
        /// </summary>
        /// <returns></returns>
        public ActionResult xyfg()
        {
  
            return View();
        }


        /// <summary>
        /// 学校简介
        /// </summary>
        /// <returns></returns>
        public ActionResult xxjj()
        {
            return View();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <param name="q"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult wznr(int id, string title,int? page)
        {
     
            ViewBag.Title = title;
            var posts = from s in db.bsuc_protal_post.Where(p => p.delete_time == 0&&p.post_status==1&&p.cates==id)
                        select s;
            ViewBag.catnameA = db.bsuc_protal_category.ToList();
            ViewBag.id = id;
            posts = posts.OrderByDescending(s => s.id);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(posts.ToPagedList(pageNumber, pageSize));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int id) {

            Bsuc_Protal_Post content = db.bsuc_protal_post.Find(id);
            if (content == null)
            {
                return HttpNotFound();
            }
            ViewBag.catnameB = db.bsuc_protal_category.ToList();
            long count = content.post_hits;
            content.post_hits = count + 1;//浏览量加一
            db.SaveChanges();
            ViewBag.Title = content.post_title;
            ViewBag.pushTime = Common.IntToDateTime(content.published_time, "yyyy-MM-dd HH:mm:ss");
            ViewBag.author = db.buser.Find(content.user_id).nickname;
            ViewBag.catename = db.bsuc_protal_category.First(c => c.id == content.cates).catname;
            return View(content);
        }


    }
}
