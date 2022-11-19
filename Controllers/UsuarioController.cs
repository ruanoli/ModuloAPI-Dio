using Microsoft.AspNetCore.Mvc;

namespace ModuloAPI_Dio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        [HttpGet("ObterDataHoraAtual")]
        public IActionResult DataHora()
        {
            var obj = new
            {
                Data = DateTime.Now.ToLongDateString(),
                Hora = DateTime.Now.ToShortTimeString()
            };

            return Ok(obj);
        }

        [HttpGet("Apresentar/{nome}")]
        public IActionResult Apresentar (string nome)
        {
            var msg = $"Olá, eu sou o {nome}";

            return Ok( new {msg});
        }
    }
}