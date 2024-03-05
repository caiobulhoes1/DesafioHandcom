namespace DesafioHandcom.Server.Interface
{
	public interface ITopic
	{
		List<TopicModel> GetAllTopics();

		public TopicModel GetTopicById(int id);
	}
}
