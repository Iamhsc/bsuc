﻿using bsuc.common.Model;
using bsuc.common;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bsuc.Areas.Admin.Controllers
{
    public class PublicController : Controller
    {
        private BsucConnectext db = new BsucConnectext();

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public object RegPost(Bsuc_User usr)
        {
            string salt = Sha1.random_string();
            usr.salt = salt;
            usr.password = Sha1.sha1_pwd(usr.password, salt);
            db.buser.Add(usr);
            db.SaveChanges();
            JObject obj = new JObject();
            obj["code"] = 1;
            obj["msg"] = "注册成功";
            obj["url"] = "/admin/public/login";
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
            obj["code"] = 0;
            var us = db.buser.Where(n => n.username == usr);
            //判断用户是否存在
            if (us.Count() <1)
            {
                obj["msg"] = "用户不存在";
                return obj;
            }
            //判断用户状态
            Bsuc_User user = us.First();
            if (user.status != 1)
            {
                obj["msg"] = "用户已被拉黑";
                return obj;
            }
            //比较密码
            if (Sha1.comparePassword(pwd, user.salt, user.password) == false)
            {
                obj["msg"] = "用户名或密码错误";
                return obj;
            }
            user.last_login_ip = Request.UserHostAddress;
            user.last_login_time = Common.GetTimeStamp();
            db.SaveChanges();
            obj["code"] = 1;
            obj["msg"] = "登陆成功";
            obj["url"] = "/admin";
            Session["user_id"] = user.id;
            Session["user_type"] = user.user_type;
            Session["user_name"] = user.username;
            Session["nick_name"] = user.nickname;
            return obj;
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return View("Login");
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
