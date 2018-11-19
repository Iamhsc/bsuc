using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bsuc.common.Model
{
    public class LayoutView
    {
        public List<Bsuc_Menu> modulemenu = new List<Bsuc_Menu>();//模块
        public ArrayList topmenu = new ArrayList();
        public LayoutView(BsucConnectext db)
        {
            db.bsuc_protal_category.ToList();
            db.bsuc_protal_post.ToList();
            db.bsuc_protal_tag.ToList();
            modulemenu = db.bmenu.Where(t => t.parent_id == 0 && t.nav == 1).ToList();
            foreach (var m in modulemenu)
            {
                topmenu.Add(db.bmenu.Where(t => t.parent_id == m.id && t.nav == 1).ToList());
            }
        }
    }
}