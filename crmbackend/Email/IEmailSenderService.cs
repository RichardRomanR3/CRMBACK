using System.Threading.Tasks;
using Dominio;

namespace crmbackend.Email {
    public interface IEmailSenderService {
        Task SendEmailAsync (MailRequest request);
    }
}