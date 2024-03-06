using DesafioHandcom.Data;
using DesafioHandcom.Server.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DesafioHandcom.Server.Controllers
{
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IComment _comment;
        private readonly AppDbContext _appDbContext;
        public CommentsController(IComment comment, AppDbContext appDbContext)
        {
            _comment = comment;
            _appDbContext = appDbContext;

        }

        [HttpPost]
        [Route("/api/comments")]
        public async Task<ActionResult<CommentModel>> AddComment([FromBody] CommentModel comment)
        {
            //Código para adicionar novo comentário no post
            try
            {
                if (comment == null)
                {
                    return BadRequest("Dados do comentário não foram fornecidos.");
                }
                var add = _comment.NewComment(comment);
                return Ok(add);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
