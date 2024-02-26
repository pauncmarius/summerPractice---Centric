using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        
    }
}
