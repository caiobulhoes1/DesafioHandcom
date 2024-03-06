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
            //Cria um novo post
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
                var postViewModels = new List<PostViewModel>();

                foreach (var post in posts)
                {
                    var postViewModel = new PostViewModel
                    {
                        Id = post.Id,
                        Title = post.Title,
                        Content = post.Content,
                        AuthorId = post.AuthorId,
                        TopicId = post.TopicId,
                        CreatedAt = post.CreatedAt,

                        // Busca o autor e o tópico pelo ID
                        Author = _appDbContext.Users.FirstOrDefault(u => u.Id == post.AuthorId),
                        Topic = _appDbContext.Topics.FirstOrDefault(t => t.Id == post.TopicId),

                        // Busca os comentários relacionados ao post
                        Comments = await _appDbContext.Comments
                            .Where(c => c.PostId == post.Id)
                            .Select(c => new CommentViewModel
                            {
                                Id = c.Id,
                                Content = c.Content,
                                AuthorId = c.AuthorId,
                                PostId = c.PostId,
                                CreatedAt = c.CreatedAt,
                                // Busca o autor pelo ID
                                Author = _appDbContext.Users.FirstOrDefault(u => u.Id == c.AuthorId)
                            })
                            .ToListAsync()
                    };

                    postViewModels.Add(postViewModel);
                }

                return postViewModels;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
