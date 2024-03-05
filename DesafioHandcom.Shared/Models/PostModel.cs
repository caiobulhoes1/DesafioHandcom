namespace DesafioHandcom
{
	public class PostModel
	{
		public int Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string Content { get; set; } = string.Empty;
		public int AuthorId { get; set; }
		public UserModel Author { get; set; }
		public int TopicId { get; set; }
		public TopicModel Topic { get; set; }
		public DateTime CreatedAt { get; set; }
	}
}
