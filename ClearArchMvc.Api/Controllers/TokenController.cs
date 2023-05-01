using CleanArchMvc.Api.Models;
using CleanArchMvc.Dominio.Account;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CleanArchMvc.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IAuthenticate _authenticate;

        public TokenController(IAuthenticate authenticate)
        {
            _authenticate = authenticate ??
                throw new ArgumentNullException(nameof(authenticate));
        }

        [HttpPost("LoginModel")]
        public async Task<ActionResult<UserTokenModel>> Login([FromBody] LoginModel loginModel)
        {
            var result = await _authenticate.Authenticate(loginModel.Email, loginModel.Password);
            if (result)
            {
                //loginModel.GenareteToken();
                return Ok("Login successful.");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login.");
                return BadRequest(ModelState);
            }
        }
        
    }
}

