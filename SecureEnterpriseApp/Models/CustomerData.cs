namespace SecureEnterpriseApp.Models
{
    public class CustomerData
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string EncryptedPhoneNumber { get; set; }

        public string EncryptedAddress { get; set; }

        public string HmacSignature { get; set; }
    }
}