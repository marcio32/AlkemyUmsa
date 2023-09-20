using AlkemyUmsa.Entities;
using AlkemyUmsa.Helper;
using Microsoft.EntityFrameworkCore;

namespace AlkemyUmsa.DataAccess.DatabaseSeeding
{
    public class AccountSeeder : IEntitySeeder
    {
        public void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasData(
                new Account
                {
                    Id = 1,
                    CreationDate = new DateTime(2023,9,20),
                    Money = 1000,
                    IsBlocked = false,
                    UserId = 1,
        });
        }
    }
}
