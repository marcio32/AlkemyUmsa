using AlkemyUmsa.Entities;
using AlkemyUmsa.Services;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace AlkemyUmsa.Logic
{
    public class GestorOperations
    {
        private readonly IUnitOfWork _unitOfWorkService;
        public GestorOperations(IUnitOfWork unitOfWork)
        {
            _unitOfWorkService = unitOfWork;
        }


        public async Task Deposit(Account account, decimal mount)
        {
            account.Money += mount;
            await _unitOfWorkService.AccountRepository.Update(account);
        }

        public async Task Transfer(Account account, Account toAccount, decimal mount)
        {

            account.Money -= mount;
            toAccount.Money += mount;

            await _unitOfWorkService.AccountRepository.Update(account);
            await _unitOfWorkService.AccountRepository.Update(toAccount);
        }
    }
}
