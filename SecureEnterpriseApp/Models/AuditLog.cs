namespace SecureEnterpriseApp.Models
{
    public class AuditLog
    {
        public int Id { get; set; }

        public string Action { get; set; }

        public string UserEmail { get; set; }

        public DateTime Timestamp { get; set; }

        public string IPAddress { get; set; }
    }
}