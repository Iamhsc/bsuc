using System.Linq;
using System.Web.Mvc;
using bsuc.common.Model;
using Newtonsoft.Json.Linq;

namespace bsuc.Areas.Admin.Controllers
{
    public class SysController : BaseController
    {
        private BsucConnectext db = new BsucConnectext();
        public ActionResult MenuAdd()
        {
            return View(db.bmenu.Where(t => t.url == "#").ToList());
        }

        [HttpPost]
        public object PostAdd(Bsuc_Menu menu)
        {
            JObject obj = new JObject();
            if (ModelState.IsValid)
            {
                db.bmenu.Add(menu);
                db.SaveChanges();
                obj["code"] = 1;
                obj["url"] = "/admin/sys/index";
                obj["msg"] = "添加成功";
            }
            else { 
            obj["code"] = 0;
            obj["msg"] = "添加失败";
            }
            return obj;
        }

        public ActionResult Index()
        {
            return View(db.bmenu.ToList());
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
