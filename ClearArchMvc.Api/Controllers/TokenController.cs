using CleanArchMvc.Api.Models;
using CleanArchMvc.Dominio.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IAuthenticate _authenticate;
        private readonly IConfiguration _configuration;

        public TokenController(IAuthenticate authenticate, IConfiguration configuration)
        {
            _authenticate = authenticate ??
                throw new ArgumentNullException(nameof(authenticate));
            _configuration = configuration;
        }

        [HttpPost("LoginModel")]
        [AllowAnonymous]
        public async Task<ActionResult<UserTokenModel>> Login([FromBody] LoginModel loginModel)
        {
            var result = await _authenticate.Authenticate(loginModel.Email, loginModel.Password);
            if (result)
            {
                return GenerateToken(loginModel);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login.");
                return BadRequest(ModelState);
            }
        }

        [HttpPost("RegisterLogin")]        
        [Authorize]
        public async Task<ActionResult> RegisterLogin([FromBody] LoginModel loginModel)
        {
            var result = await _authenticate.RegisterUser(loginModel.Email, loginModel.Password);
            if (result) 
            {
                return Ok("Register successfull");
            }
            else 
            {
                ModelState.AddModelError(string.Empty, "Invalid register");
                return BadRequest(ModelState); 
            }
        }

        private UserTokenModel GenerateToken(LoginModel userInfo)
        {
            var claims = new[]
            {
                new Claim("email", userInfo.Email),
                new Claim("qualquervalor", "qualquerclaimdesejada"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var keyPrivate = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));

            var signingCredentials = new SigningCredentials(keyPrivate, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddMinutes(10);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: expiration,
                signingCredentials: signingCredentials
                );

            return new UserTokenModel
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
    }
}

