using AlkemyUmsa.DataAccess;
using AlkemyUmsa.DataAccess.Repositories;

namespace AlkemyUmsa.Services
{
    public class UnitOfWorkService : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UserRepository UserRepository { get; private set; }

        public UnitOfWorkService(ApplicationDbContext context)
        {
            _context = context;
            UserRepository = new UserRepository(_context);
        }
       
    }
}
