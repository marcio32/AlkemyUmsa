using AlkemyUmsa.DataAccess.Repositories.Interfaces;
using AlkemyUmsa.DTOs;
using AlkemyUmsa.Entities;
using AlkemyUmsa.Helper;
using Microsoft.EntityFrameworkCore;

namespace AlkemyUmsa.DataAccess.Repositories
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {

        public AccountRepository(ApplicationDbContext context) : base(context)
        {

        }

        public override async Task<bool> Update(Account updateAccount)
        {
            var Account = await _context.Accounts.FirstOrDefaultAsync(x => x.Id == updateAccount.Id);
            if (Account == null) { return false; }

            Account.Money = updateAccount.Money;
            Account.IsBlocked = updateAccount.IsBlocked;
       

            _context.Accounts.Update(Account);
            return true;
        }

        public override async Task<bool> Delete(int id)
        {
            var Account = await _context.Accounts.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (Account != null)
            {
                _context.Accounts.Remove(Account);
            }

            return true;
        }

    }
}
