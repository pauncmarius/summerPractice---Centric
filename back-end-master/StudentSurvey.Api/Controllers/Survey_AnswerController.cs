using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyHotel.Domain.Entities;
using StudentSurvey.Business.Models;
using StudentSurvey.Business.Services.IServices;

namespace StudentSurvey.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Survey_AnswerController : ControllerBase
    {
        private readonly ISurvey_AnswerService _surveyService;

        public Survey_AnswerController(ISurvey_AnswerService surveyService)
        {
            _surveyService = surveyService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult AddSurvey([FromBody] Survey_AnswerModel survey)
        {
            var surveyResult = _surveyService.AddSurvey_Answer(survey);
            return CreatedAtAction(null, surveyResult);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_surveyService.GetSurvey_Answers());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var survey = _surveyService.GetSurvey_Answer(id);
            {
                if (survey != null)
                {
                    return Ok(survey);
                }
                return NotFound();
            }
                
        }

        [HttpPut]
        public IActionResult Update([FromBody] Survey_Answers survey)
        {
            _surveyService.UpdateSurvey_Answer(survey);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _surveyService.DeleteSurvey_Answer(id);
            return NoContent();
        }


    }
}

