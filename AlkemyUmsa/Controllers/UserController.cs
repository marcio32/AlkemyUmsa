using AlkemyUmsa.DTOs;
using AlkemyUmsa.Entities;
using AlkemyUmsa.Helper;
using AlkemyUmsa.Infrastructure;
using AlkemyUmsa.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlkemyUmsa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        ///  Devuelve todo los usuarios
        /// </summary>
        /// <returns>retorna todos los usuarios</returns>

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _unitOfWork.UserRepository.GetAll();
            int pageToShow = 1;

            if (Request.Query.ContainsKey("page")) int.TryParse(Request.Query["page"], out pageToShow);

            var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();
            
            var paginateUsers = PaginateHelper.Paginate(users, pageToShow, url);

            return ResponseFactory.CreateSuccessResponse(200, paginateUsers);
        }

        /// <summary>
        ///  Registra el usuario
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>devuelve un usuario registrado con un statusCode 201</returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto dto)
        {

            if (await _unitOfWork.UserRepository.UserEx(dto.Email)) return ResponseFactory.CreateErrorResponse(409, $"Ya existe un usuario registrado con el mail:{dto.Email}");
            var user = new User(dto);
            await _unitOfWork.UserRepository.Insert(user);
            await _unitOfWork.Complete(); 

            return ResponseFactory.CreateSuccessResponse(201, "Usuario registrado con exito!");
        }

        /// <summary>
        ///  Actualiza el usuario
        /// </summary>
        /// <returns>actualizado o un 500</returns>
        [Authorize(Policy = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, RegisterDto dto)
        {
        var result = await _unitOfWork.UserRepository.Update(new User(dto, id));

            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se pudo eliminar el usuario");
            }
            else
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Actualizado");
            }
        }


        /// <summary>
        ///  Elimina el usuario
        /// </summary>
        /// <returns>Eliminado o un 500</returns>
        [Authorize(Policy = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _unitOfWork.UserRepository.Delete(id);

            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se pudo eliminar el usuario");
            }
            else
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Actualizado");
            }
        }

    }
}
