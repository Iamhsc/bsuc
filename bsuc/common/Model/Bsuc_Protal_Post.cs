
namespace bsuc.common.Model
{
    /// <summary>
    /// 文章模型
    /// </summary>
    public class Bsuc_Protal_Post
    {
        private BsucConnectext db = new BsucConnectext();

        public long id { get; set; }
        public string post_title { get; set; }
        public string post_excerpt { get; set; }//摘要
        public string post_ketwords { get; set; }//关键字
        public string post_content { get; set; }//内容
        public long post_hits { get; set; }//查看数
        public long post_like { get; set; }//点赞数
        public long user_id { get; set; }//发布者id
        public int published_time { get; set; }//发布时间
        public int update_time { get; set; }//更新时间
        public int delete_time { get; set; }//删除时间
        public long comment_count { get; set; }//评论数
        public byte comment_status { get; set; }//是否允许评论
        public byte is_top { get; set; }//是否制置顶
        public byte post_status { get; set; }//是否发布
    }
}