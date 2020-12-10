using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieShop.Core.Models.Request;
using MovieShop.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MovieShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterUser(UserRegisterRequestModel userRegisterRequest)
        {
            if (ModelState.IsValid)
            {
                // calll user servce
                return Ok(await _userService.CreateUser(userRegisterRequest));
            }
            return BadRequest(new { message = "please correct the input infomation" });

        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            var user = await _userService.GetUserDetails(id);
            if (user == null)
            {
                return NotFound("No User Found");
            }
            return Ok(user);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginRequestModel loginRequest)
        {
            if (!ModelState.IsValid) return BadRequest(new {message ="Model State Invalid"});
            var user = await _userService.ValidateUser(loginRequest.Email, loginRequest.Password);
            if (user == null)
            {
                return BadRequest(new { message = "invalid log in attempt" });
            }
            // only sucessfully loged in
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Surname,  user.LastName),
                new Claim(ClaimTypes.NameIdentifier,  user.Id.ToString())
            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));
            return Ok();
        }

    }
}
