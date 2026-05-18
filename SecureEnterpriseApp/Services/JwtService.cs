using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SecureEnterpriseApp.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SecureEnterpriseApp.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;

        private readonly UserManager<ApplicationUser> _userManager;

        public JwtService(
            IConfiguration configuration,
            UserManager<ApplicationUser> userManager)
        {
            _configuration = configuration;

            _userManager = userManager;
        }

        public async Task<string> GenerateToken(ApplicationUser user)
        {
            var userRoles =
                await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),

                new Claim(JwtRegisteredClaimNames.Jti,
                    Guid.NewGuid().ToString()),

                new Claim(ClaimTypes.NameIdentifier, user.Id),

                new Claim(ClaimTypes.Email, user.Email)
            };

            foreach (var role in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key =
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(
                        _configuration["Jwt:Key"]));

            var creds =
                new SigningCredentials(
                    key,
                    SecurityAlgorithms.HmacSha256);

            var expires =
                DateTime.Now.AddMinutes(
                    Convert.ToDouble(
                        _configuration["Jwt:DurationInMinutes"]));

            var token =
                new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],

                    audience: _configuration["Jwt:Audience"],

                    claims: claims,

                    expires: expires,

                    signingCredentials: creds
                );

            return new JwtSecurityTokenHandler()
                .WriteToken(token);
        }
    }
}