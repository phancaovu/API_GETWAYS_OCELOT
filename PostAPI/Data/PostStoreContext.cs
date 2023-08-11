using Microsoft.EntityFrameworkCore;
using PostAPI.Models;
namespace PostAPI.Data
{
    public class PostStoreContext : DbContext
    {
        public PostStoreContext(DbContextOptions<PostStoreContext> otp ) : base(otp)  {
        }

       public DbSet<PostModels>? PostModelss { get; set; }
    }
}
