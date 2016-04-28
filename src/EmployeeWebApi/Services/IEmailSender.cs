using System.Threading.Tasks;

namespace EmployeeWebApi.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
