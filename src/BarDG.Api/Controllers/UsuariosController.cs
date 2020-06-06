using BarDG.Api.Configuration;
using BarDG.Domain.Usuarios.Dto;
using BarDG.Domain.Usuarios.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace BarDG.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ApiBase
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly AuthSettings authorizationSettings;

        public UsuariosController(IUsuarioRepository usuarioRepository, 
            IOptions<AuthSettings> authorizationOptions) : base(null)
        {
            this.usuarioRepository = usuarioRepository;
            authorizationSettings = authorizationOptions.Value;
        }

        public IOptions<AuthSettings> AuthorizationSettings { get; }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest login)
        {
            var valido = usuarioRepository.Login(login.Email, login.Senha);

            if(valido)
            {
                return Ok(new LoginResponse
                    {
                        Email = login.Email,
                        Token = TokenService.Gerar(login.Email, authorizationSettings)
                    });
            }

            return BadRequest("Usuário ou senha inválidos");
        }
    }
}