using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SecureEnterpriseApp.DTOs;
using SecureEnterpriseApp.Models;
using SecureEnterpriseApp.Services;

namespace SecureEnterpriseApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly IJwtService _jwtService;

        public AuthController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            IJwtService jwtService)
        {
            _userManager = userManager;

            _signInManager = signInManager;

            _roleManager = roleManager;

            _jwtService = jwtService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            var userExists =
                await _userManager.FindByEmailAsync(model.Email);

            if (userExists != null)
            {
                return BadRequest("User already exists");
            }

            ApplicationUser user = new()
            {
                Email = model.Email,

                UserName = model.Email,

                FullName = model.FullName
            };

            var result =
                await _userManager.CreateAsync(
                    user,
                    model.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            // Create Role if not exists
            if (!await _roleManager.RoleExistsAsync(model.Role))
            {
                await _roleManager.CreateAsync(
                    new IdentityRole(model.Role));
            }

            // Assign Role to User
            await _userManager.AddToRoleAsync(
                user,
                model.Role);

            return Ok("User registered successfully");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto model)
        {
            var user =
                await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return Unauthorized("Invalid email");
            }

            var result =
                await _signInManager.CheckPasswordSignInAsync(
                    user,
                    model.Password,
                    false);

            if (!result.Succeeded)
            {
                return Unauthorized("Invalid password");
            }

            var token =
                await _jwtService.GenerateToken(user);

            return Ok(new
            {
                Token = token
            });
        }
    }
}