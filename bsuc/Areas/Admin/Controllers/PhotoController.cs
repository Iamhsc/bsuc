using bsuc.common;
using bsuc.common.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bsuc.Areas.Admin.Controllers
{
    public class PhotoController : BaseController
    {
        private BsucConnectext db = new BsucConnectext();
        public ActionResult add()
        {
            return View();
        }

        [HttpPost]
        public object upload(HttpPostedFileBase fileData)
        {
            var fileimg = Request.Files;
            if (fileData == null || string.IsNullOrEmpty(fileData.FileName) || fileData.ContentLength == 0)
            {
                return Json(new { flag = false, message = "没有需要上传的文件" });
            }
            string file = Path.GetFileName(fileData.FileName);//获得文件名
            string extension = Path.GetExtension(fileData.FileName);//获得文件扩展名 
            int uploadDate = Common.GetTimeStamp();//上传时间
            string savedbname = Path.GetFileNameWithoutExtension(fileData.FileName) + uploadDate + extension; //保存到数据库的文件名
            string fullsaveName = System.Web.HttpContext.Current.Request.MapPath("~\\Public\\upload\\") + savedbname;//完整路径
            fileData.SaveAs(fullsaveName);
            return Json(new { code = 1, mag = "上传成功", data = new { name = file + extension, path = "~/Public/upload/" + savedbname } });
        }

        [HttpPost]
        public object add(Bsuc_Protal_Photo photo)
        {
            db.bsuc_protal_photo.Add(photo);
            db.SaveChanges();
            return Json(new { code=1});
        }
    }
}
