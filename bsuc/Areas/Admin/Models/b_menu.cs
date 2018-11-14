using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bsuc.Areas.Admin.Models
{
    public class b_menu
    {
        public int id { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public int sort { get; set; }
        public byte system { get; set; }
        public byte nav { get; set; }
        public byte status { get; set; }
        public int ctime { get; set; }
    }
}