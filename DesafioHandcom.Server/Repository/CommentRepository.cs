using DesafioHandcom.Data;
using DesafioHandcom.Server.Interface;

namespace DesafioHandcom.Server.Repository
{
    public class CommentRepository : IComment
    {
        private readonly AppDbContext _appDbContext;
        public CommentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public CommentModel NewComment(CommentModel model)
        {
            _appDbContext.Comments.Add(model);
            _appDbContext.SaveChanges();
            return model;
        }
    }
}
