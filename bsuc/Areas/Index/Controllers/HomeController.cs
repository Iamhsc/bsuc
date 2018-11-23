﻿using bsuc.common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bsuc.Areas.Index.Controllers
{
    public class HomeController : Controller
    {
        private BsucConnectext db = new BsucConnectext();
        ///一级目录
        
        /// <summary>
        /// 官网首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            //获取文章类别为1（学校要闻）的文章；
            ViewBag.news = db.bsuc_protal_post.Where(p => p.cates == 1).Take(10).OrderByDescending(p=>p.id).ToList();
            //获取文章类别为2（通知公告）的文章;
            ViewBag.newa = db.bsuc_protal_post.Where(p => p.cates == 2).Take(8).OrderByDescending(p => p.id).ToList();
            //获取文章类别为3（招标信息）的文章;
            ViewBag.newb = db.bsuc_protal_post.Where(p => p.cates == 3).Take(8).OrderByDescending(p => p.id).ToList();
            //获取文章类别为4（部门动态）的文章
            ViewBag.bmdt = db.bsuc_protal_post.Where(p => p.cates == 4).Take(8).OrderByDescending(p => p.id).ToList();
            //获取文章类别为5（部门动态）的文章
            ViewBag.ztbd = db.bsuc_protal_post.Where(p => p.cates == 5).Take(8).OrderByDescending(p => p.id).ToList();
            //获取文章类别为6（百院媒体）的文章
            ViewBag.bymt = db.bsuc_protal_post.Where(p => p.cates == 6).Take(8).OrderByDescending(p => p.id).ToList();
            //获取文章类别为7（科学研究）的文章
            ViewBag.kxyj = db.bsuc_protal_post.Where(p => p.cates == 7).Take(8).OrderByDescending(p => p.id).ToList();
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

        /// <summary>
        /// 校园要闻
        /// </summary>
        /// <returns></returns>
        public ActionResult xxyw()
        {
            ViewBag.catnameA = db.bsuc_protal_category.ToList();         
            return View();
        }

    }
}
