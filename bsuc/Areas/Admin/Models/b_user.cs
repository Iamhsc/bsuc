using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace bsuc.Areas.Admin.Models
{
    public class b_user
    {
        public int id { get; set; }
        public string username { get; set; }
        public byte sex { get; set; }
        public DateTime birthday { get; set; }
        public string nickname { get; set; }
        public string email { get; set; }
        public string avatar { get; set; }
        public string password { get; set; }

        public string salt { get; set; }
    }
}
