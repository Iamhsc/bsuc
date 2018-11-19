using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bsuc.Areas.Index.Controllers
{
    public class HomeController : Controller
    {
        

        /// <summary>
        /// 官网首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 学校概况
        /// </summary>
        /// <returns></returns>
        public ActionResult xxgk()
        {
            return View();
        }

    }
}
