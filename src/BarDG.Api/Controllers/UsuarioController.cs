using BarDG.Api.Configuration;
using BarDG.Domain.Usuarios.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace BarDG.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly AuthSettings authorizationSettings;

        public UsuarioController(IUsuarioRepository usuarioRepository, 
            IOptions<AuthSettings> authorizationOptions)
        {
            this.usuarioRepository = usuarioRepository;
            authorizationSettings = authorizationOptions.Value;
        }

        public IOptions<AuthSettings> AuthorizationSettings { get; }

        [HttpGet("login")]
        public IActionResult Login(string email, string senha)
        {
            var valido = usuarioRepository.Login(email, senha);

            if(valido)
            {
                return Ok(TokenService.Gerar(email, authorizationSettings));
            }

            return BadRequest();
        }
    }
}