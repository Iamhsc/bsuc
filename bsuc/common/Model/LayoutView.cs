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
            modulemenu = db.bmenu.Where(t => t.parent_id == 0).ToList();
            foreach (var m in modulemenu)
            {
                topmenu.Add(db.bmenu.Where(t => t.parent_id == m.id).ToList());
            }
        }
    }
}