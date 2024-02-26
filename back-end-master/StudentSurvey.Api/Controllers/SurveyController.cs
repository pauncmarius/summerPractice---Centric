using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyHotel.Domain.Entities;
using StudentSurvey.Business.Models;
using StudentSurvey.Business.Services.IServices;

namespace StudentSurvey.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly ISurveyService _surveyService;

        public SurveyController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult AddSurvey([FromBody] SurveyModel survey)
        {
            var surveyResult = _surveyService.AddSurvey(survey);
            return CreatedAtAction(null, surveyResult);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_surveyService.GetSurveys());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var survey = _surveyService.GetSurvey(id);
            {
                if (survey != null)
                {
                    return Ok(survey);
                }
                return NotFound();
            }
                
        }

        [HttpPut]
        public IActionResult Update([FromBody] Survey survey)
        {
            _surveyService.UpdateSurvey(survey);
            return NoContent();
        }
        [HttpDelete("{name}")]
        public IActionResult Delete(string name)
        {
            _surveyService.DeleteByName(name);
            return NoContent();
        }


    }
}

