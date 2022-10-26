using APICapstoneProject.Models;
using System.Threading.Tasks;

namespace APICapstoneProject.Services
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
        
    }
}
