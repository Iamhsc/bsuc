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
        public object add(Bsuc_Protal_Photo photo)
        {
            db.bsuc_protal_photo.Add(photo);
            db.SaveChanges();
            return Json(new { code=1});
        }
    }
}
