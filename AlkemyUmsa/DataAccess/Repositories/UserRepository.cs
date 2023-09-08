using AlkemyUmsa.DataAccess.Repositories.Interfaces;
using AlkemyUmsa.DTOs;
using AlkemyUmsa.Entities;
using Microsoft.EntityFrameworkCore;

namespace AlkemyUmsa.DataAccess.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {

        public UserRepository(ApplicationDbContext context) : base(context)
        {
                
        }


        public async Task<User?> AuthenticateCredentials(AuthenticateDto dto)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.Email == dto.Email && x.Password == dto.Password);
        }
    }
}
