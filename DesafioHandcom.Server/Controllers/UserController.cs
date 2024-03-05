using DesafioHandcom.Server.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DesafioHandcom.Server.Controllers
{
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IUser _user;

        public UserController(IUser user)
        {
            _user = user;
        }

		[HttpGet]
		[Route("GetAuthorById")]
		public async Task<ActionResult<UserModel>> GetById([FromQuery] int id)
		{
			var getAuthor = _user.GetAuthorById(id);
			return getAuthor == null ? NotFound() : Ok(getAuthor);
		}
	}
}
