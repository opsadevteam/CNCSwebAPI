

using CNCSwebApiProject.Models;
using CNCSwebApiProject.Services.JwtService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;


namespace CNCSwebApiProject.Controllers

{
    [Route("api/v1/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly JwtService _jwtService;

        public AccountController(JwtService jwtService)
        {
            _jwtService = jwtService;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult<LoginResponseModel>> Login([FromBody] LoginRequestModel request)
        {
            var result = await _jwtService.Authenticate(request);
            if (result is null)
                return Unauthorized();

            var options = new CookieOptions
            {
                IsEssential = true,
                HttpOnly = true,
                Secure = true, // Only for HTTPS
                SameSite = SameSiteMode.None, // Necessary for cross-origin
                Expires = DateTime.UtcNow.AddHours(1) // Set expiration time
                
            };
            Response.Cookies.Append("auth_token", result.AccessToken, options);

            return result;

        }
    }
}
