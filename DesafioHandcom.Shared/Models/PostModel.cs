using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DesafioHandcom
{
	public class PostModel
	{
		public int Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string Content { get; set; } = string.Empty;
		public int AuthorId { get; set; }		
		public int TopicId { get; set; }		
		public DateTime CreatedAt { get; set; }

	}

	public class PostViewModel
	{
		public int Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string Content { get; set; } = string.Empty;
		public int AuthorId { get; set; }
		public int TopicId { get; set; }
		public DateTime CreatedAt { get; set; }
		public TopicModel Topic { get; set; }
		public UserModel Author { get; set; }
        public List<CommentViewModel> Comments { get; set; }
    }
}
