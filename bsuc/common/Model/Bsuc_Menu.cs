
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
    }
}