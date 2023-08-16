using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Registration.Model;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace Registration.Data
{
    public class DbContextClass : DbContext
    {
        public DbContextClass(DbContextOptions<DbContextClass> options) : base(options) 
        {
            //options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<User> Users { get; set; }
    }
}
