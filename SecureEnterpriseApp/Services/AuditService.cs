using SecureEnterpriseApp.Models;

namespace SecureEnterpriseApp.Services
{
    public class AuditService
    {
        private static readonly List<AuditLog> logs = new();

        public void Log(string action, string email, string ip)
        {
            logs.Add(new AuditLog
            {
                Action = action,
                UserEmail = email,
                IPAddress = ip,
                Timestamp = DateTime.UtcNow
            });
        }

        public List<AuditLog> GetLogs()
        {
            return logs;
        }
    }
}