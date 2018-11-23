using bsuc.common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace bsuc.common.Model
{
    public class Bsuc_Menu
    {
        private BsucConnectext db = new BsucConnectext();

        public int id { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public int parent_id { get; set; }
        public int sort { get; set; }
        public byte system { get; set; }
        public byte nav { get; set; }
        public byte status { get; set; }
        public int ctime { get; set; }

        public Bsuc_Menu getBrandCrumbs(int id=0)
        {
            if (id == 0)
            {
                return null;
            }
            Bsuc_Menu menu = new Bsuc_Menu();
            menu = db.bmenu.First(b => b.id == id);
            if (menu.parent_id > 0)
            {
                menu = this.getBrandCrumbs(menu.id);
            }
            return menu;
        }
    }
}