using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LIBRARY_SYSTEM_PRACTICE.DTOs.AuthDTOs;
using LIBRARY_SYSTEM_PRACTICE.Models;
using LIBRARY_SYSTEM_PRACTICE.Reposatories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace LIBRARY_SYSTEM_PRACTICE.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        private readonly IConfiguration _config;

        public AuthController(IUnitOfWork unit, IConfiguration config)
        {
            _unit = unit;
            _config = config;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDTO DTO)
        {
            if (DTO is null)
                return Unauthorized();

            var item = _unit.userRepo.GetUserByUserName(DTO.UserName);

            if(item.PasswordHash != DTO.PasswordHash)
                return Unauthorized();

            var Token = GenerateJWTToken(item);

            return Ok(new { Token });

        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] RegisterDTO DTO)
        {
            if (DTO is null)
                return Unauthorized();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ExsitUserName = _unit.userRepo.GetUserByUserName(DTO.UserName);

            if (ExsitUserName != null)
                return BadRequest("UserName Has Already Taken");

            var passwordHasher = new Microsoft.AspNetCore.Identity.PasswordHasher<User>();

            var Entity = new User
            {
                UserName = DTO.UserName,
                PasswordHash = passwordHasher.HashPassword(null!,DTO.Password),
                Role = "Member"
            };


            return Ok(new { Message = "User registered successfully", UserId = Entity.Id });
        }

        private string GenerateJWTToken(User user)
        {
            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(Key,SecurityAlgorithms.HmacSha256);


            var Claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier , user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.Role,user.Role)
            };


            var token = new JwtSecurityToken(
             
                issuer : _config["Jwt:Issuer"],
                audience : _config["Jwt:Audience"],
                claims : Claims,
                expires : DateTime.Now.AddMinutes(Convert.ToDouble(_config["Jwt:DurationInMinutes"])),
                signingCredentials : creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}
