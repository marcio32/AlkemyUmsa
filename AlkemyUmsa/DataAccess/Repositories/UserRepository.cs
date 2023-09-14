using AlkemyUmsa.DataAccess.Repositories.Interfaces;
using AlkemyUmsa.DTOs;
using AlkemyUmsa.Entities;
using AlkemyUmsa.Helper;
using Microsoft.EntityFrameworkCore;

namespace AlkemyUmsa.DataAccess.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {

        public UserRepository(ApplicationDbContext context) : base(context)
        {

        }

        public override async Task<bool> Update(User updateUser)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == updateUser.Id);
            if (user == null) { return false; }

            user.FirstName = updateUser.FirstName;
            user.LastName = updateUser.LastName;
            user.Email = updateUser.Email;
            user.Password = updateUser.Password;

            _context.Users.Update(user);
            return true;
        }

        public override async Task<bool> Delete(int id)
        {
            var user = await _context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (user != null)
            {
                _context.Users.Remove(user);
            }

            return true;
        }

        public async Task<User?> AuthenticateCredentials(AuthenticateDto dto)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.Email == dto.Email && x.Password == PasswordEncryptHelper.EncryptPassword(dto.Password));
        }
    }
}


