using AlkemyUmsa.DTOs;
using AlkemyUmsa.Entities;
using AlkemyUmsa.Helper;
using AlkemyUmsa.Infrastructure;
using AlkemyUmsa.Logic;
using AlkemyUmsa.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlkemyUmsa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AccountController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public AccountController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        /// <summary>
        ///  Obtengo todos los Accounts
        /// </summary>
        /// <returns>devuelde todos los Accounts</returns>

        [HttpGet]
      
        public async Task<IActionResult> GetAll()
        {
            var Accounts = await _unitOfWork.AccountRepository.GetAll();
            int pageToShow = 1;
            if (Request.Query.ContainsKey("page")) int.TryParse(Request.Query["page"], out pageToShow);
            var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();
            var paginateUsers = PaginateHelper.Paginate(Accounts, pageToShow, url);

            return ResponseFactory.CreateSuccessResponse(200, paginateUsers);
        }


        /// <summary>
        ///  Inserta un cuenta
        /// </summary>
        /// <returns>Devuelve un mensaje de confirmacion del agrego del cuenta</returns>
        [Authorize(Policy = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Insert(AccountCreateDto dto)
        {
           
            var Account = new Account
            {
                UserId = dto.UserId
            };
            await _unitOfWork.AccountRepository.Insert(Account);
            await _unitOfWork.Complete();
            return ResponseFactory.CreateSuccessResponse(200, "Se agrego el cuenta");
        }


        /// <summary>
        ///  Actualiza un cuenta
        /// </summary>
        /// <returns>Devuelve un mensaje de actualizacion de cuenta</returns>
        [Authorize(Policy = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(AccountDto dto)
        {
            var Account = new Account
            {
                Id = dto.Id,
                Money = dto.Money,
                IsBlocked = dto.IsBlocked,
                UserId = dto.UserId,
                CreationDate = dto.CreationDate
            };
            var result = await _unitOfWork.AccountRepository.Update(Account);
            await _unitOfWork.Complete();
            return ResponseFactory.CreateSuccessResponse(200, "Se actualizo el cuenta");
        }


        /// <summary>
        ///  Elimina un cuenta
        /// </summary>
        /// <returns>Devuelve un mensaje de eliminacion del cuenta</returns>
        [Authorize(Policy = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _unitOfWork.AccountRepository.Delete(id);
            await _unitOfWork.Complete();
            return ResponseFactory.CreateSuccessResponse(200, "Se elimino el cuenta");
        }


        /// <summary>
        ///  Deposito a mi cuenta
        /// </summary>
        /// <returns>Devuelve un mensaje de monto depositado</returns>
        [Authorize(Policy = "Admin")]
        [HttpPost("deposit/{id}")]
        public async Task<IActionResult> Deposit([FromRoute] int id, AccountDepositDto dto)
        {

            Account? account;
            account = await _unitOfWork.AccountRepository.GetById(id);
            if (account == null) return BadRequest(false);

            await new GestorOperations(_unitOfWork).Deposit(account, dto.Mount);

            await _unitOfWork.Complete();
            return ResponseFactory.CreateSuccessResponse(200, "Monto Depositado");
        }


        /// <summary>
        ///  Transfiero a otra cuenta
        /// </summary>
        /// <returns>Devuelve un mensaje de monto transferido</returns>
        [Authorize(Policy = "Admin")]
        [HttpPost("transfer/{id}")]
        public async Task<IActionResult> Transfer([FromRoute] int id, AccountTransferDto dto)
        {
            //Mi Cuenta
            Account? account;
            account = await _unitOfWork.AccountRepository.GetById(id);
            if (account == null) return BadRequest(false);

            //Cuenta a transferir 
            Account? toAccount;
            toAccount = await _unitOfWork.AccountRepository.GetById(dto.IdUser);
            if (toAccount == null) return BadRequest(false);

            await new GestorOperations(_unitOfWork).Transfer(account, toAccount, dto.Mount);

            await _unitOfWork.Complete();
            return ResponseFactory.CreateSuccessResponse(200, "Monto Transferido");
        }

    }
}
