using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecureEnterpriseApp.DTOs;
using SecureEnterpriseApp.Models;
using SecureEnterpriseApp.Security;
using SecureEnterpriseApp.Services;

namespace SecureEnterpriseApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SecurityController : ControllerBase
    {
        private readonly EncryptionService _encryption;

        private readonly HmacService _hmac;

        private readonly AuditService _audit;

        private static readonly List<CustomerData> database =
            new();

        public SecurityController(
            EncryptionService encryption,
            HmacService hmac,
            AuditService audit)
        {
            _encryption = encryption;

            _hmac = hmac;

            _audit = audit;
        }

        [HttpPost("save")]
        public IActionResult Save(CustomerDataDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Email))
            {
                return BadRequest("Email required");
            }

            var encryptedPhone =
                _encryption.Encrypt(dto.PhoneNumber);

            var encryptedAddress =
                _encryption.Encrypt(dto.Address);

            var signature =
                _hmac.GenerateHmac(dto.Email);

            CustomerData customer = new()
            {
                Id = database.Count + 1,

                FullName = dto.FullName,

                Email = dto.Email,

                EncryptedPhoneNumber = encryptedPhone,

                EncryptedAddress = encryptedAddress,

                HmacSignature = signature
            };

            database.Add(customer);

            _audit.Log(
                "Customer Data Saved",
                dto.Email,
                HttpContext.Connection.RemoteIpAddress?.ToString());

            return Ok(customer);
        }

        [HttpGet("logs")]
        [Authorize(Roles = "Admin")]
        public IActionResult Logs()
        {
            return Ok(_audit.GetLogs());
        }
    }
}