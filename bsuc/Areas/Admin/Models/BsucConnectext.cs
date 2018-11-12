using System.Data.Entity;

namespace bsuc.Areas.Admin.Models
{
    public class BsucConnectext : DbContext
    {
        public DbSet<b_user> buser { get; set; }
    }
}