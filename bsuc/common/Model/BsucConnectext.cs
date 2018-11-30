using System.Data.Entity;

namespace bsuc.common.Model
{
    public class BsucConnectext : DbContext
    {
        public DbSet<Bsuc_User> buser { get; set; }
        public DbSet<Bsuc_Menu> bmenu { get; set; }
        public DbSet<Bsuc_Protal_Post> bsuc_protal_post { get; set; }
        public DbSet<Bsuc_Protal_Category> bsuc_protal_category { get; set; }
        public DbSet<Bsuc_Protal_Photo> bsuc_protal_photo { get; set; }
        public DbSet<Bsuc_Role> bsuc_role { get; set; }
    }
}