using Microsoft.EntityFrameworkCore;
using Registration.Model;

namespace Registration.Data
{
    public class DbContextClass : DbContext
    {
        public DbContextClass(DbContextOptions<DbContextClass> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
