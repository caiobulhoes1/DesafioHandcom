namespace DesafioHandcom
{
	public class CommentModel
	{
		public int Id { get; set; }
		public string Content { get; set; } = string.Empty;
		public int AuthorId { get; set; }
		public UserModel Author { get; set; }
		public int PostId { get; set; }
		public PostModel Post { get; set; }
		public DateTime CreatedAt { get; set; }
	}
}
