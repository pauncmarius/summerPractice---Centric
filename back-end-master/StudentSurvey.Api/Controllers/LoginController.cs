using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyHotel.Domain.Entities;
using StudentSurvey.Business.Models;
using StudentSurvey.Business.Services.IServices;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StudentSurvey.Api.Controllers
{
   
    [ApiController]
    [Route("api/auth")]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost, Route("login")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult Login([FromBody] UserLoginModel user)
        {
            if (user == null)
                return BadRequest("InvalidRequest");
            try
            {
                if (user.Email.Equals(_userService.GetUser(_userService.GetByEmail(user.Email)).Email)
                     && user.Password.Equals(_userService.GetUser(_userService.GetByEmail(user.Email)).Hashed_Password))
                {
                    Console.WriteLine(_userService.GetUser(_userService.GetByEmail(user.Email)));
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("VERY_SECURE_AND_UNBREAKEABLE_KEY"));
                    var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(
                        issuer: "https://localhost:44365",
                        audience: "https://localhost:44365",
                        claims: new List<Claim>(),
                        expires: DateTime.Now.AddMinutes(15),
                         signingCredentials: signingCredentials
                        );

                    var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
                    return Ok(new { Token = tokenString });
                }
                    

                Console.WriteLine(_userService.GetUser(_userService.GetByEmail(user.Email)));
                return Unauthorized();
            }
            catch (NullReferenceException)
            {
                return BadRequest("Invalid email or password: ");
            }

        }

    }

}