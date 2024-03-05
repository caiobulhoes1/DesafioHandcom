using DesafioHandcom.Client;
using DesafioHandcom.Data;
using DesafioHandcom.Server.Service;
using Microsoft.AspNetCore.Mvc;

namespace DesafioHandcom.Server.Controllers
{
    [ApiController]
    public class LoginController : ControllerBase
    {
		private readonly CustomAuthProvider _customAuthProvider;
		private readonly JwtService _service;
		private readonly AppDbContext _appDbContext;

		public LoginController(CustomAuthProvider customAuthProvider, JwtService service, AppDbContext appDbContext)
		{
			_service = service;
			_customAuthProvider = customAuthProvider;
			_appDbContext = appDbContext;
		}

		[HttpPost]
		[Route("/efetuarlogin")]
		public async Task<IActionResult> Login(UserModel user)
		{
			var getUser = _appDbContext.Users.FirstOrDefault(m => m.Email == user.Email && m.Password == user.Password);
			if (getUser == null)
			{
				return BadRequest("Usu�rio n�o encontrado");
			}
			else
			{
				//Inicia cria��o do Token Jwt
				var token = _service.Create(user);
				Response.Headers.Add("Authorization", "Bearer " + token);
				return Ok();
			}
		}
	}

}
