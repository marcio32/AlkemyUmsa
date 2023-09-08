using AlkemyUmsa.DataAccess.Repositories;

namespace AlkemyUmsa.Services
{
    public interface IUnitOfWork
    {
        public UserRepository UserRepository { get; }
     
    }
}
