using Microsoft.EntityFrameworkCore;

namespace AlkemyUmsa.DataAccess.DatabaseSeeding
{
    public interface IEntitySeeder
    {
        void SeedDatabase(ModelBuilder modelBuilder);
    }
}
