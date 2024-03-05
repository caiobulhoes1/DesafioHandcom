using DesafioHandcom.Data;
using DesafioHandcom.Server.Interface;

namespace DesafioHandcom.Server.Repository
{
	public class TopicRepository : ITopic
	{
		private readonly AppDbContext _appDbContext;
        public TopicRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public List<TopicModel> GetAllTopics()
		{
			return _appDbContext.Topics.ToList();
		}

		public TopicModel GetTopicById(int id)
		{
			return _appDbContext.Topics.FirstOrDefault(x => x.Id == id);
		}
	}
}
