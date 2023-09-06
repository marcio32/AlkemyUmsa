using AlkemyUmsa.DataAccess.Repositories.Interfaces;
using AlkemyUmsa.Entities;

namespace AlkemyUmsa.DataAccess.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {

        public UserRepository(ApplicationDbContext context) : base(context)
        {
                
        }
    }
}
