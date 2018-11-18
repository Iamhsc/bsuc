using System.Data.Entity;

namespace bsuc.common.Model
{
    public class BsucConnectext : DbContext
    {
        public DbSet<Bsuc_User> buser { get; set; }
        public DbSet<Bsuc_Menu> bmenu { get; set; }
    }
}