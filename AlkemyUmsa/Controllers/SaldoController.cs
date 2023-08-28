using AlkemyUmsa.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AlkemyUmsa.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SaldoController : ControllerBase
    {

        [HttpGet]
        [Route("Consultar")]
        public IActionResult Consultar()
        {
            return Ok(190);
        }

        [HttpPost]
        [Route("Agregar")]
        public IActionResult AgregarSaldo()
        {
            return Unauthorized("Hola");
        }
    }
}