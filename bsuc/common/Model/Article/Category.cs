using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bsuc.common.Model.Article
{
    /// <summary>
    /// 文章类别模型
    /// </summary>
    public class Category
    {
        public int id { get; set; }//id
        public int cid { get; set; }
        public string catname { get; set; }//分类名
        public int ctime { get; set; }//创建时间
        public byte is_del { get; set; }//是否删除
    }
}