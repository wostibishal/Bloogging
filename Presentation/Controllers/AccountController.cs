using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _config;
        private readonly SignInManager<AppUser> _signInManager;
        public record LoginResponse(bool Flag, string Token, string Message);
        public record UserSession(string? Id, string? Name, string? Email, string? Role);
        public AccountController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration config, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _config = config;
            _signInManager = signInManager;
        }

        [HttpPost("registerUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new AppUser { UserName = model.Email, Email = model.Email };

            // Ensure the role exists
            var roleExists = await _roleManager.RoleExistsAsync(model.Role);
            if (!roleExists)
            {
                return BadRequest($"Role '{model.Role}' does not exist.");
            }

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            // Assign the role to the user
            var roleResult = await _userManager.AddToRoleAsync(user, model.Role);
            if (!roleResult.Succeeded)
            {
                return BadRequest(roleResult.Errors);
            }

            return Ok("User registered successfully.");
        }
        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var users = _userManager.Users.ToList();
            return Ok(users);
        }
        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return Ok("Succeeded");
            }
            return BadRequest(result.Errors);
        }
        [HttpPut("EditProfile")]
        public async Task<IActionResult> EditProfile(AppUser appUser)
        {
            var user = await _userManager.FindByIdAsync(appUser.Id);
            if (user == null)
            {
                return NotFound();
            }
            user.PhoneNumber = appUser.PhoneNumber;
            user.UserName = appUser.Email;
            user.Email = appUser.Email;
            user.NormalizedEmail = appUser.Email.ToUpper();
            user.EmailConfirmed = appUser.EmailConfirmed;

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return Ok(user);
            }
            return BadRequest();
        }
        [HttpPut("UpdatePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordVM model, string userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(model);
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var changePasswordResult = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.Password);
            if (changePasswordResult.Succeeded)
            {
                return Ok(model);
            }

            return BadRequest(changePasswordResult.Errors);
        }
        [HttpPost]
        [Route("LoginUser")]
        public async Task<LoginResponse> Login([FromBody] LoginUser loginUser)
        {
            var result = await _signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false, lockoutOnFailure: false);
            if (result.Succeeded)
            {

                var getUser = await _userManager.FindByEmailAsync(loginUser.Email);
                var getUserRole = await _userManager.GetRolesAsync(getUser);
                var userSession = new UserSession(getUser.Id, getUser.UserName, getUser.Email, getUserRole.First());
                string token = GenerateToken(userSession);

                return new LoginResponse(true, token!, "Login completed");

            }
            else
            {
                return new LoginResponse(false, null!, "Login not completed");
            }
        }

        private string GenerateToken(UserSession user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userClaims = new[]
           {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: userClaims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
