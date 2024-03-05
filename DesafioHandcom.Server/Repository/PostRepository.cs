using DesafioHandcom.Data;
using DesafioHandcom.Server.Interface;

namespace DesafioHandcom.Server.Repository
{
	public class PostRepository : IPost
	{
		private readonly AppDbContext _appDbContext;
        public PostRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

		public List<PostModel> GetAllPosts()
		{
			return _appDbContext.Posts.ToList();
		}

		public PostModel NewPost(PostModel model)
		{
			_appDbContext.Posts.Add(model);
			_appDbContext.SaveChanges();
			return model;
		}
	}
}
