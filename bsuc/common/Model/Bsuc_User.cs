using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace bsuc.common.Model
{
    public class Bsuc_User
    {
        public int id { get; set; }
        public byte user_type { get; set; }
        public string username { get; set; }
        public string salt { get; set; }
        public string password { get; set; }
        public byte sex { get; set; }
        public DateTime birthday { get; set; }
        public int ctime { get; set; }
        public byte status { get; set; }
        public string nickname { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }
        public string avatar { get; set; }
        public string more { get; set; }
        public int last_login_time { get; set; }
        public string last_login_ip { get; set; }
    }
}
