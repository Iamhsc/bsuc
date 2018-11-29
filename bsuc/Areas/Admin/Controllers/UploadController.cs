using bsuc.common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bsuc.Areas.Admin.Controllers
{
    public class UploadController : Controller
    {
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
            string fullsaveName = System.Web.HttpContext.Current.Request.MapPath("~\\Upload\\") + savedbname;//完整路径
            fileData.SaveAs(fullsaveName);
            return Json(new { code = 1, mag = "上传成功", data = new { name = file, path = "/Upload/" + savedbname } });
        }

    }
}
