namespace DesafioHandcom.Server.Interface
{
	public interface IPost
	{
		public PostModel NewPost(PostModel model);

		public List<PostModel> GetAllPosts();
	}
}
