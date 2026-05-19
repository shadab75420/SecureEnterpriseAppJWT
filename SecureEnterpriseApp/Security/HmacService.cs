using System.Security.Cryptography;
using System.Text;

namespace SecureEnterpriseApp.Security
{
    public class HmacService
    {
        private readonly string secret =
            "SUPER_SECRET_HMAC_KEY";

        public string GenerateHmac(string data)
        {
            using HMACSHA256 hmac =
                new(Encoding.UTF8.GetBytes(secret));

            byte[] hash =
                hmac.ComputeHash(
                    Encoding.UTF8.GetBytes(data));

            return Convert.ToBase64String(hash);
        }
    }
}