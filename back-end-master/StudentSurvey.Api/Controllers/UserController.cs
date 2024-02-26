using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyHotel.Domain.Entities;
using StudentSurvey.Business.Models;
using StudentSurvey.Business.Services.IServices;

namespace StudentSurvey.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }



        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult AddUser([FromBody] UserModel user)
        {
            var userResult = _userService.AddUser(user);
            return CreatedAtAction(null, userResult);
        }

        [HttpGet]

        public IActionResult GetAll()
        {
            return Ok(_userService.GetUsers());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetUser(id);
            {
                if (user != null)
                {
                    return Ok(user);
                }
                return NotFound();
            }
        }


        [HttpPut]
        public IActionResult Update([FromBody] User user)
        {
            _userService.UpdateUser(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userService.DeleteUser(id);
            return NoContent();

        }


    }



}