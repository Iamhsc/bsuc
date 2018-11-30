using bsuc.common;
using bsuc.common.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bsuc.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        private BsucConnectext db = new BsucConnectext();


        public ActionResult Index()
        {
            ViewBag.Title = "标签管理";
            List<Bsuc_Protal_Category> category = db.bsuc_protal_category.ToList();
            return View(category);
        }

        public ActionResult Add()
        {
            ViewBag.Title = "标签添加";
            return View();
        }

        [HttpPost]
        public object AddPost(Bsuc_Protal_Category cate)
        {
            cate.ctime = Common.GetTimeStamp();
            db.bsuc_protal_category.Add(cate);
            db.SaveChanges();
            JObject obj = new JObject();
            obj["code"] = 1;
            obj["msg"] = "添加成功";
            obj["url"] = "/admin/category/index";
            return obj;
        }

        public ActionResult Edit(int id)
        {
            Bsuc_Protal_Category cate = db.bsuc_protal_category.Find(id);
            if (cate == null)
            {
                return HttpNotFound();
            }
            ViewBag.Title = "编辑";
            ViewBag.cate = cate;
            return View();
        }

        [HttpPost]
        public object Edit(Bsuc_Protal_Category cate)
        {
            db.Entry(cate).State = EntityState.Modified;
            db.SaveChanges();
            JObject obj = new JObject();
            obj["code"] = 1;
            obj["msg"] = "修改成功";
            obj["url"] = "/admin/category/index";
            return obj;
        }

        /// <summary>
        /// 标签删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public object Delete(int id)
        {
            Bsuc_Protal_Category cate = db.bsuc_protal_category.Find(id);
            db.bsuc_protal_category.Remove(cate);
            db.SaveChanges();
            JObject obj = new JObject();
            obj["code"] = 1;
            obj["msg"] = "删除成功";
            return obj;
        }
    }
}
