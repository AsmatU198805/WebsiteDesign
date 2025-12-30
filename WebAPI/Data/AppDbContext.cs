using WebAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<TblOrderMaster> TblOrderMaster { get; set; }
        public DbSet<TblOrderDetail> TblOrderDetail { get; set; }


    }
}
