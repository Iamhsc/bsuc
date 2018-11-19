using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bsuc.common.Model
{
    /// <summary>
    /// 文章类别模型
    /// </summary>
    public class Bsuc_Protal_Category
    {
        public int id { get; set; }//id
        public int parent { get; set; } //分类父id
        public string catname { get; set; }//分类名
        public string description { get; set; }//分类描述
        public int ctime { get; set; }//创建时间
        public byte is_del { get; set; }//是否删除
    }
}