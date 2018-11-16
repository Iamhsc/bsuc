using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bsuc.Areas.Admin.Models
{
    public class LayoutView
    {
        public ArrayList arrls=new ArrayList();
        public List<b_menu> itemls;
        public List<b_menu> topmenu;
        public LayoutView(BsucConnectext db)
        {
            topmenu = db.bmenu.Where(t => t.parent_id == 0).ToList();
            foreach (var item in topmenu)
            {
                itemls=db.bmenu.Where(s => s.parent_id == item.id).ToList();
                arrls.Add(itemls);
            }
        }
    }
}