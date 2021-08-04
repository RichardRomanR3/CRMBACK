using System.Threading.Tasks;
using crmbackend.Email;
using Dominio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace crmbackend.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class EmailController : ControllerBase {
        private readonly IEmailSenderService _IMailer;
        public EmailController (IEmailSenderService IMailer) {
            _IMailer = IMailer;
        }

        [HttpPost]
        public async Task Ejecuta (MailRequest data) {
            await _IMailer.SendEmailAsync (data);
        }
    }
}