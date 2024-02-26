using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyHotel.Domain.Entities;
using StudentSurvey.Business.Models;
using StudentSurvey.Business.Services.IServices;

namespace StudentSurvey.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly ITopicService _topicService;

        public TopicController(ITopicService topicService)
        {
            _topicService = topicService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult AddTopic([FromBody] TopicModel topic)
        {
            var topicResult = _topicService.AddTopic(topic);
            return CreatedAtAction(null, topicResult);
        }

        [HttpGet]

        public IActionResult GetAll()
        {
            return Ok(_topicService.GetTopics());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var topic = _topicService.GetTopic(id);
            {
                if (topic != null)
                {
                    return Ok(topic);
                }
                return NotFound();
            }

        }

        [HttpPut]
        public IActionResult Update([FromBody] Topics topic)
        {
            _topicService.UpdateTopic(topic);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _topicService.DeleteTopic(id);
            return NoContent();

        }
    }
}