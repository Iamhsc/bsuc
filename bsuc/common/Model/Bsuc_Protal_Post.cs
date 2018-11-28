
using System.Collections.Generic;
using System.Linq;
namespace bsuc.common.Model
{
    /// <summary>
    /// 文章模型
    /// </summary>
    public class Bsuc_Protal_Post
    {
        /// <summary>
        /// id
        /// </summary>
        public long id { get; set; }
        /// <summary>
        /// 文章标题
        /// </summary>
        public string post_title { get; set; }
        /// <summary>
        /// 文章类别
        /// </summary>
        public int cates { get; set; }
        /// <summary>
        /// 图片链接
        /// </summary>
        public string cober { get; set; }
        /// <summary>
        /// 摘要
        /// </summary>
        public string post_excerpt { get; set; }
        /// <summary>
        /// 关键字
        /// </summary>
        public string post_ketwords { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string post_content { get; set; }
        /// <summary>
        /// 查看数
        /// </summary>
        public long post_hits { get; set; }
        /// <summary>
        /// 点赞数
        /// </summary>
        public long post_like { get; set; }
        /// <summary>
        /// 发布者id
        /// </summary>
        public long user_id { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        public int published_time { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public int update_time { get; set; }
        /// <summary>
        /// 删除时间
        /// </summary>
        public int delete_time { get; set; }
        /// <summary>
        /// 评论数
        /// </summary>
        public long comment_count { get; set; }
        /// <summary>
        /// 是否允许评论
        /// </summary>
        public byte comment_status { get; set; }
        /// <summary>
        /// 是否制置顶
        /// </summary>
        public byte is_top { get; set; }
        /// <summary>
        /// 是否发布
        /// </summary>
        public byte post_status { get; set; }

    }
}