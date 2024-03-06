using DesafioHandcom.Server.Interface;
using DesafioHandcom.Shared.DTO;
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

            if (getAuthor == null)
            {
                return NotFound();
            }

            var userDto = new UserDTO
            {
                Id = getAuthor.Id,
                Name = getAuthor.Name,
                Email = getAuthor.Email,
                CreatedAt = getAuthor.CreatedAt
            };

            return Ok(userDto);
		}

        [HttpGet]
        [Route("/api/getAllAuthors")]
        public async Task<ActionResult<List<UserDTO>>> GetAuthors()
        {
            var listAuthors = _user.GetAllAuthors().Select(userDto => new UserDTO
            {
                Id = userDto.Id,
                Name = userDto.Name,
                Email = userDto.Email,
                CreatedAt = userDto.CreatedAt
            }).ToList();

            return listAuthors == null ? NotFound() : Ok(listAuthors);
        }
    }
}
