using bsuc.common;
using bsuc.common.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bsuc.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {

        private BsucConnectext db = new BsucConnectext();

        public ActionResult Index()
        {
            ViewBag.Title = "用户管理";
            List<Bsuc_User> users = db.buser.ToList();
            ViewBag.user = users;
            return View();
        }

        public ActionResult Edit() {
            return View();
        }

        public ActionResult Add() {
            return View();
        }

        [HttpPost]
        public object Add(Bsuc_User usr) {
            string salt = Sha1.random_string();
            int t = Common.GetTimeStamp();
            usr.salt = salt;
            usr.password = Sha1.sha1_pwd(usr.password, salt);
            usr.ctime = t;
            usr.last_login_time = t;
            db.buser.Add(usr);
            db.SaveChanges();
            JObject obj = new JObject();
            obj["code"] = 1;
            obj["msg"] = "添加成功";
            obj["url"] = "/admin/user";
            return obj;
            }

        /// <summary>
        /// 设置状态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public object status(int id) {
            Bsuc_User users = db.buser.Find(id);
            int sta=users.status;
            sta = 1 - sta;
            users.status = (byte)sta;
            db.SaveChanges();
            JObject obj = new JObject();
            obj["code"] = 1;
            obj["msg"] = "成功";
            return obj;
        }
    }
}
