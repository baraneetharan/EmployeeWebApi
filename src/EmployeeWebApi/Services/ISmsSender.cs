using System.Threading.Tasks;

namespace EmployeeWebApi.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
