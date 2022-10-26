using ElevatorReport.Data.Entities.App.Login_SignUp;
using ElevatorReport.Data.Entities.Common;
using ElevatorReport.Data.Entities.Results;
using ElevatorReport.Data.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ElevatorReport.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountService _accountService;

        public AccountController(
            AccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (request == null)
                return BadRequest();

            var result = await  _accountService.LoginAsync(request);

            if(!result.Success)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var result = await _accountService.CreateUserAsync(request, new [] { RepositoryDefaults.Role.User });

            return Ok(result);
        }


        [HttpGet("/logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            await HttpContext.SignOutAsync(IdentityConstants.TwoFactorRememberMeScheme);
            await HttpContext.SignOutAsync(IdentityConstants.TwoFactorUserIdScheme);

            return Ok("/login");
        }

        //[HttpPost]
        //[Route("register-admin")]
        //public async Task<IActionResult> RegisterAdmin([FromBody] RegisterRequest model)
        //{
        //    var userExists = await _userManager.FindByNameAsync(model.Username);
        //    if (userExists != null)
        //        return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

        //    IdentityUser user = new()
        //    {
        //        Email = model.Email,
        //        SecurityStamp = Guid.NewGuid().ToString(),
        //        UserName = model.Username
        //    };
        //    var result = await _userManager.CreateAsync(user, model.Password);
        //    if (!result.Succeeded)
        //        return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

        //    if (!await _roleManager.RoleExistsAsync(RepositoryDefaults.Role.Administrator))
        //        await _roleManager.CreateAsync(new IdentityRole(RepositoryDefaults.Role.Administrator));
        //    if (!await _roleManager.RoleExistsAsync(RepositoryDefaults.Role.User))
        //        await _roleManager.CreateAsync(new IdentityRole(RepositoryDefaults.Role.User));

        //    if (await _roleManager.RoleExistsAsync(RepositoryDefaults.Role.Administrator))
        //    {
        //        await _userManager.AddToRoleAsync(user, RepositoryDefaults.Role.Administrator);
        //    }
        //    if (await _roleManager.RoleExistsAsync(RepositoryDefaults.Role.Administrator))
        //    {
        //        await _userManager.AddToRoleAsync(user, RepositoryDefaults.Role.User);
        //    }
        //    return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        //}

    }
}
