using UserAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace UserAPI.Data
{
    public class UserStoreContext : DbContext
    {
        //public class BookStoreContext : IdentityDbContext<ApplicationUser>
        public UserStoreContext(DbContextOptions<UserStoreContext> opt) : base(opt)
        {

        }

        #region DbSet
        public DbSet<User>? Users { get; set; }
        #endregion
    }
}
