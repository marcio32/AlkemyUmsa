using AlkemyUmsa.Entities;
using Microsoft.EntityFrameworkCore;

namespace AlkemyUmsa.DataAccess.DatabaseSeeding
{
    public class UserSeeder : IEntitySeeder
    {
        public void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FirstName = "Marcio",
                    LastName =  "Abriola",
                    Email  = "marcioabriola@yahoo.com",
                    Password = "1234"
                });
        }
    }
}
