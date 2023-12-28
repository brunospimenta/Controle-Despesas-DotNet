using ControleDeDespesas.Data.Dtos.Usuario;
using ControleDeDespesas.Services;
using ControleDeDespesas.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeDespesas.Controllers
{
    [EnableCors("AllowOrigin")]
    [ApiController]
    [Route("[Controller]")]
    public class UsuarioController : ControllerBase
    {
        private UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("cadastro")]
        public async Task<IActionResult> Cadastra(CreateUsuarioDto dto)
        {
            await _usuarioService.Cadastra(dto);

            //Logger.CreateLog("Usuario Criado", Enums.LogType.SUCESS, "UserAutentication");
            return Ok("Usuario Cadastrado:\n" + dto.Username);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUsuarioDto dto)
        {
            var token = await _usuarioService.Login(dto);

            //Logger.CreateLog("Usuario autenticado e token foi gerado", Enums.LogType.INFO, "UserAutentication");
            return Ok(token);
        }
    }

    
}
