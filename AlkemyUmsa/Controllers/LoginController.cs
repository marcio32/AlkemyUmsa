using AlkemyUmsa.DTOs;
using AlkemyUmsa.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlkemyUmsa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {


        [HttpGet]
        [Route("Usuarios")]
        public IActionResult Usuarios(bool todos)
        {
            if (todos)
            {
                return Ok("Todos los usuarios");
            }
            else
            {
                return Ok("Un usuario");
            }
        }

        [HttpPost]
        public IActionResult Login(LoginDto login)
        {
            if (login.Usuario == "Marcio" && login.Clave == "1234")
            {
                return Ok("token: awdawdawdawd");
            }
            else
            {
                return Unauthorized("Usuario o Clave Erronea");
            }
        }

        [HttpPut]
        [Route("Editar")]
        public IActionResult EditarLogin(LoginDto login)
        {
            return Ok(login);
        }

        [HttpDelete]
        [Route("Eliminar")]
        public IActionResult EliminarLogin(int id)
        {
            return Ok($"Se elimino el elemento {id} correctamente");
        }


    }
}
