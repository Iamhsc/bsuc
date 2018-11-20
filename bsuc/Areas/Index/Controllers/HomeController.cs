using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bsuc.Areas.Index.Controllers
{
    public class HomeController : Controller
    {
        ///一级目录
        
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

        ///二级目录

        /// <summary>
        /// 学校简介
        /// </summary>
        /// <returns></returns>
        public ActionResult xxjj()
        {
            return View();
        }

    }
}
