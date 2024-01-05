using Microsoft.EntityFrameworkCore;

namespace Teploobmen.Data
{
    public class MyApplicationContext : DbContext
    {
        public DbSet<InData> inDatas { get; set; }
        public DbSet<User> Users { get; set; }

        public MyApplicationContext (DbContextOptions<MyApplicationContext> options) : base (options)
        {

        }
    }
}
