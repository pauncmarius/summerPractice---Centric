using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyHotel.Domain.Entities;
using StudentSurvey.Business.Models;
using StudentSurvey.Business.Services.IServices;

namespace StudentSurvey.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        
        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult AddQuestion([FromBody] QuestionModel question)
        {
            var questionResult = _questionService.AddQuestion(question);

            return CreatedAtAction(null, questionResult);


        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_questionService.GetQuestions());
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var question = _questionService.GetQuestion(id);
            {
                if (question != null)
                {
                    return Ok(question);
                }
                return NotFound();
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] Questions question)
        {
            _questionService.UpdateQuestion(question);
            return NoContent();
        }

        [HttpDelete("{id}")]
        
        public IActionResult Delete(int id)
        {
            _questionService.DeleteQuestion(id);
            return NoContent();
        }
        
        

    }
}
