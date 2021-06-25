using BackEndPreguntas.Domain.IServices;
using BackEndPreguntas.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BackEndPreguntas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService LoginService;
        public LoginController(ILoginService loginService)
        {
            this.LoginService = loginService;
        }

        [Route("Authentication")]
        [HttpPost]
        public IActionResult Login([FromBody]Users users)
        {
            AuthenticateResponse resp = this.LoginService.Login(users);
            if(resp.id >= 0)
            {
                return Ok(resp);
            }
            return BadRequest("Usuario o Contraseña inccorrectos");
        }
    }
}
