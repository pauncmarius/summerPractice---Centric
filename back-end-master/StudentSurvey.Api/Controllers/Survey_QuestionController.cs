using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyHotel.Domain.Entities;
using StudentSurvey.Business.Models;
using StudentSurvey.Business.Services.IServices;

namespace StudentSurvey.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Survey_QuestionController : ControllerBase
    {
        private readonly ISurvey_QuestionService _surveyService;

        public Survey_QuestionController(ISurvey_QuestionService surveyService)
        {
            _surveyService = surveyService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult AddSurvey([FromBody] Survey_QuestionModel survey)
        {
            var surveyResult = _surveyService.AddSurvey_Question(survey);
            return CreatedAtAction(null, surveyResult);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_surveyService.GetSurvey_Questions());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var survey = _surveyService.GetSurvey_Question(id);
            {
                if (survey != null)
                {
                    return Ok(survey);
                }
                return NotFound();
            }
                
        }

        [HttpPut]
        public IActionResult Update([FromBody] Survey_Questions survey)
        {
            _surveyService.UpdateSurvey_Question(survey);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _surveyService.DeleteSurvey_Question(id);
            return NoContent();
        }


    }
}

