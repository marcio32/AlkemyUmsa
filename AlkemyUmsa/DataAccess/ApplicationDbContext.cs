using AlkemyUmsa.DataAccess.DatabaseSeeding;
using AlkemyUmsa.Entities;
using Microsoft.EntityFrameworkCore;

namespace AlkemyUmsa.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var seeders = new List<IEntitySeeder>
            {
                new UserSeeder(),
                new RoleSeeder(),
                new AccountSeeder()
            };

            foreach (var seeder in seeders) {

                seeder.SeedDatabase(modelBuilder);
            }

            base.OnModelCreating(modelBuilder);
        }

        

    }
}
