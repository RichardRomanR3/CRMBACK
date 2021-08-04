using System;
using System.Threading.Tasks;
using Dominio;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace crmbackend.Email {
    public class EmailSenderService : IEmailSenderService {
        private readonly SmtpSettings _smtpSettings;
        public EmailSenderService (IOptions<SmtpSettings> smtpSettings) {
            _smtpSettings = smtpSettings.Value;
        }
        public async Task SendEmailAsync (MailRequest request) {
            try {
                var message = new MimeMessage ();

                message.From.Add (new MailboxAddress (_smtpSettings.SenderName, _smtpSettings.SenderEmail));
                message.To.Add (new MailboxAddress ("Cobrador CRM", request.Email));
                message.Subject = request.Subject;
                message.Body = new TextPart ("html") { Text = request.Body };

                using (var client = new SmtpClient ()) {
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    client.AuthenticationMechanisms.Remove ("XOAUTH2");
                    client.Timeout = 10 * 1000;
                    await client.ConnectAsync (_smtpSettings.Server);
                    await client.AuthenticateAsync (_smtpSettings.UserName, _smtpSettings.Password);
                    await client.SendAsync (message);
                    await client.DisconnectAsync (true);
                }

            } catch (Exception) {

            }
        }
    }
}