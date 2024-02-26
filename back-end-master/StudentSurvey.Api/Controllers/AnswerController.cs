using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyHotel.Domain.Entities;
using StudentSurvey.Business.Models;
using StudentSurvey.Business.Services.IServices;

namespace StudentSurvey.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AnswerController : ControllerBase
    {
        private readonly IAnswerService _answerService;

        public AnswerController(IAnswerService answerService)
        {
            _answerService = answerService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult AddAnswer([FromBody] AnswerModel answer)
        {
            var answerResult = _answerService.AddAnswer(answer);
            return CreatedAtAction(null, answerResult);
        }

        [HttpGet]

        public IActionResult GetAll()
        {
            return Ok(_answerService.GetAnswers());
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var question = _answerService.GetAnswer(id);
            {
                if (question != null)
                {
                    return Ok(question);
                }
                return NotFound();
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] Answers answer)
        {
            _answerService.UpdateAnswer(answer);
            return NoContent();
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            _answerService.DeleteAnswer(id);
            return NoContent();
        }

    }


}
