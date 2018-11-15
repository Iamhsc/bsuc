using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bsuc.Areas.Admin.Models
{
    public class LayoutView
    {
        public ArrayList arrls = new ArrayList();
        public ArrayList arrlsitem=new ArrayList();
        public List<b_menu> lsitem;
        public List<b_menu> topmenu;
        private Array arr;
        public List<b_menu> secondmenu;
        public LayoutView(BsucConnectext db)
        {
            topmenu = db.bmenu.Where(t => t.parent_id == 0).ToList();
            foreach (var item in topmenu)
            {
                lsitem = db.bmenu.Where(s => s.parent_id == item.id).ToList();
                arrls.Add(lsitem);
            }
        }
    }
}