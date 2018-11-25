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
