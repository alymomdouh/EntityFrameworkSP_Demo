using EntityFrameworkSP_Demo.entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkSP_Demo.Data
{
    // to inhert from DbContext install package Microsoft.EntityFrameworkCore
    public class DbContextClass : DbContext
    {
        protected readonly IConfiguration Configuration;
        public DbContextClass(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // to use UseSqlServer Microsoft.EntityFrameworkCore.SqlServer
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }
        public DbSet<Product> Product { get; set; }
    }
}
