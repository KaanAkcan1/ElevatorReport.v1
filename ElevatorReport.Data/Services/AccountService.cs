using ElevatorReport.Data.Entities.App.Login_SignUp;
using ElevatorReport.Data.Entities.Results;
using ElevatorReport.Data.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ElevatorReport.Data.Services
{
    public class AccountService
    {
        private readonly UserService _userService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AccountService(
            UserService userService, 
            UserManager<IdentityUser> userManager, 
            RoleManager<IdentityRole> roleManager,
            SignInManager<IdentityUser> signInManager,
            IConfiguration configuration
            )
        {
            _userService = userService;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        #region Create Process
        public async Task<DataResponse<IdentityUser>> CreateUserAsync(RegisterRequest request, string[] roles)
        {
            if (request == null)
                return new DataResponse<IdentityUser> { Message = "request came null" };

            var appUserCreateResult = await CreateAppUserAsync(request, roles);

            if (!appUserCreateResult.Success)
                return appUserCreateResult;

            var userId = Guid.Parse((await _userManager.FindByNameAsync(request.Username)).Id);

            var userCreateSuccess = await _userService.CreateUserAsync(request , userId);

            if (!userCreateSuccess.Success)
            {
                await _userManager.DeleteAsync(appUserCreateResult.Data);

                return new DataResponse<IdentityUser> { Message = userCreateSuccess.Message };
            }

            return appUserCreateResult;
        }

        private async Task<DataResponse<IdentityUser>> CreateAppUserAsync(RegisterRequest request, string[] roles)
        {            
            var appUserCreateResult =  await CreateAppUserAsync(request);

            if (!appUserCreateResult.Success)
                return appUserCreateResult;
            

            if (roles != null)
            {
                var isAddRoleSuccessful = await AddRoleToAppUserAsync(appUserCreateResult.Data, roles);

                if (!isAddRoleSuccessful.Success)
                {
                    await _userManager.DeleteAsync(appUserCreateResult.Data);

                    return new DataResponse<IdentityUser> { Message = appUserCreateResult.Message };
                }                    
            }

            return appUserCreateResult;
        }
        
        private async Task<DataResponse<IdentityUser>> CreateAppUserAsync(RegisterRequest request)
        {
            var isUserExist = await _userManager.FindByEmailAsync(request.Email);

            if (isUserExist != null)
            {
                return new DataResponse<IdentityUser> { Success = false, Status = "Error", Message = "User already exists!" };
            }

            IdentityUser user = new()
            {
                Email = request.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = request.Username
            };

            var isCreateSuccessful = await _userManager.CreateAsync(user, request.Password);

            if (!isCreateSuccessful.Succeeded)
                return new DataResponse<IdentityUser> { Success = false, Status = "Error", Message = "User creation failed! Please check user details and try again." + ErrorManupulator.ErrorArrayToString(isCreateSuccessful.Errors) };

            return new DataResponse<IdentityUser> { Success = true, Status = "Success", Data = user, Message = "User created!" };
        }
        #endregion

        public async Task<Response> AddRoleToAppUserAsync(IdentityUser user, string[] roles)
        {
            if (user == null || roles == null)
                return new Response { Success = false, Status = "Error", Message = "Functions variables came null" };

            foreach(var role in roles)
            {
                if(!await _roleManager.RoleExistsAsync(role))
                    await _roleManager.CreateAsync(new IdentityRole(role));
                else
                    await _userManager.AddToRoleAsync(user, role);
            }

            return new Response { Success = true, Status = "Roles Added" };
        }

        public async Task<DataResponse<LoginToken>> LoginAsync (LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.Username);

            if (user == null)
                return new DataResponse<LoginToken> { Message = "User couldn't find" };

            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if(signInResult == null || !signInResult.Succeeded)
                return new DataResponse<LoginToken> { Message = "Sign in operation couldn't be success" };

            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var token = GetToken(authClaims);

            var result = new LoginToken
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = token.ValidTo
            };

            return new DataResponse<LoginToken> { Success = true, Data = result};
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}
