using HospitalSystem.Core.Entities;
using System.Net;
using System.Net.Mail;

namespace HospitalSystem.Infrastructure.Services
{
    public class EmailSender : IEmailSender
    {
        public readonly EmailConfiguration _emailConfi;

        public EmailSender(EmailConfiguration emailConfi)
        {
            _emailConfi = emailConfi;
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var FromMail = _emailConfi.From;
            var FromPassword = _emailConfi.Password;
            var message = new MailMessage();
            message.From = new MailAddress(FromMail);
            message.Subject = subject;
            message.To.Add(email);
            message.Body = $"<html><body>{htmlMessage}</body></html>";
            message.IsBodyHtml = true;

            var smtpClient = new SmtpClient(_emailConfi.SmtpServer)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(FromMail, FromPassword),
                Port = _emailConfi.Port,

            };

            smtpClient.Send(message);

            return Task.CompletedTask;
        }
    }
}
