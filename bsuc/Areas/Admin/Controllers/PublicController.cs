using bsuc.Areas.Admin.Models;
using bsuc.common;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bsuc.Areas.Admin.Controllers
{
    public class PublicController : BaseController
    {
        private BsucConnectext db = new BsucConnectext();

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public object RegPost(b_user usr)
        {
            string salt = Sha1.random_string();
            usr.salt = salt;
            usr.password = Sha1.sha1_pwd(usr.password, salt);
            db.buser.Add(usr);
            db.SaveChanges();
            JObject obj = new JObject();
            obj["code"] = 1;
            obj["msg"] = "注册成功";
            return obj;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public object LoginPost()
        {
            string usr = Request.Form["username"];//用户名
            string pwd = Request.Form["password"];//密码
            JObject obj = new JObject();
            var us = db.buser.Where(n => n.username == usr);
            if (us.Count() > 0)
            {
                var user = us.First();
                if (Sha1.comparePassword(pwd, user.salt, user.password))
                {
                    obj["code"] = 1;
                    obj["msg"] = "登陆成功";
                    obj["url"] = "/admin";
                    Session["user_id"] = user.id;
                    Session["user_name"] = user.username;
                }
                else
                {

                    obj["code"] = 0;
                    obj["msg"] = "用户名或密码错误";
                }
            }
            else
            {
                obj["code"] = 0;
                obj["msg"] = "用户不存在";
            }
            return obj;
        }
        //
        // GET: /Admin/Public/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Admin/Public/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Admin/Public/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Public/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/Public/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Admin/Public/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/Public/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Admin/Public/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
