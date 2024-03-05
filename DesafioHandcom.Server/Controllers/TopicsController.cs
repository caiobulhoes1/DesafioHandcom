using DesafioHandcom.Server.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DesafioHandcom.Server.Controllers
{
	[ApiController]
	public class TopicsController : ControllerBase
	{
		private readonly ITopic _topic;

        public TopicsController(ITopic topic)
        {
            _topic = topic;
        }

        [HttpGet]
		[Route("GetTopics")]
		public async Task<ActionResult<List<TopicModel>>> GetAllTopics()
		{
			var topics = _topic.GetAllTopics();
			return Ok(topics);
		}

		[HttpGet]
		[Route("GetTopicById")]
		public async Task<ActionResult<UserModel>> GetById([FromQuery] int id)
		{
			var getTopic = _topic.GetTopicById(id);
			return getTopic == null ? NotFound() : Ok(getTopic);
		}
	}

}
