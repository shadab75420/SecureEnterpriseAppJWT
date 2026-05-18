using SecureEnterpriseApp.Models;

namespace SecureEnterpriseApp.Services
{
    public interface IJwtService
    {
        Task<string> GenerateToken(ApplicationUser user);
    }
}