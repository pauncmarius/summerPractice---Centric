using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }

   
}
