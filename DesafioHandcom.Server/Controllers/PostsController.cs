using DesafioHandcom.Data;
using DesafioHandcom.Server.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesafioHandcom.Server.Controllers
{
	[ApiController]
	public class PostsController : ControllerBase
	{
		private readonly IPost _post;
		private readonly AppDbContext _appDbContext;
        public PostsController(IPost post, AppDbContext appDbContext)
        {
            _post = post;
			_appDbContext = appDbContext;
        }

		[HttpPost]
		[Route("/api/posts")]
		public async Task<ActionResult<PostModel>> AddPost([FromBody] PostModel post)
		{
			try
			{
				if (post == null)
				{
					return BadRequest("Dados do post não foram fornecidos.");
				}
				var add = _post.NewPost(post);
				return Ok(add);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet]
		[Route("GetPosts")]
		public async Task<ActionResult<List<PostViewModel>>> GetPosts()
		{
			try
			{
				// Busca todos os posts
				var posts = await _appDbContext.Posts.ToListAsync();

				// Mapeia os PostModels para PostViewModels
				var postViewModels = posts.Select(post => new PostViewModel
				{
					Id = post.Id,
					Title = post.Title,
					Content = post.Content,
					AuthorId = post.AuthorId,
					TopicId = post.TopicId,
					CreatedAt = post.CreatedAt,
					// Busca o autor e o tópico pelo ID
					Author = _appDbContext.Users.FirstOrDefault(u => u.Id == post.AuthorId),
					Topic = _appDbContext.Topics.FirstOrDefault(t => t.Id == post.TopicId)
				}).ToList();

				return postViewModels;
			}
			catch (Exception ex)
			{
				throw new Exception("An error occurred while retrieving posts.", ex);
			}
		}
	}
}
