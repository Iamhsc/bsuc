using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bsuc.common.Model
{
    public class Bsuc_Protal_Photo
    {
        public int id { get; set; }
        public int phototype { get; set; }
        public string photoname { get; set; }
        public string photourl { get; set; }
        public string href { get; set; }
        public int uploadtime { get; set; }
        public int postid { get; set; }
    }
}