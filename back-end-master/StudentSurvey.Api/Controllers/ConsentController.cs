using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyHotel.Domain.Entities;
using StudentSurvey.Business.Models;
using StudentSurvey.Business.Services.IServices;

namespace StudentSurvey.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsentController : ControllerBase
    {
        private readonly IConsentService _consentService;

        public ConsentController(IConsentService consentService)
        {
            _consentService = consentService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult AddConsent([FromBody] ConsentModel consent)
        {
            var consentResult = _consentService.AddConsent(consent);
            return CreatedAtAction(null, consentResult);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_consentService.GetConsents());
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var consent = _consentService.GetConsent(id);
            if(consent!=null)
            {
                return Ok(consent);
            }
            return NotFound();
        }

        [HttpPut]
        public IActionResult Update([FromBody] Consent consent)
        {
            _consentService.UpdateConsent(consent);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _consentService.DeleteConsent(id);
            return NoContent();
        }

    }

}