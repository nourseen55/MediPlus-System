using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using MailKit.Security;

namespace HospitalSystem.Infrastructure.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var smtpSettings = _configuration.GetSection("Smtp");

            // Create the email message
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(smtpSettings["FromName"], smtpSettings["From"]));
            message.To.Add(new MailboxAddress(email, email));
            message.Subject = subject;

            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = htmlMessage
            };
            message.Body = bodyBuilder.ToMessageBody();

            // Send the email
            using (var client = new SmtpClient())
            {
                /*try
                {
                    // Use STARTTLS for port 587
                    client.Connect(smtpSettings["Host"], int.Parse(smtpSettings["Port"]), SecureSocketOptions.StartTls);

                    // Authenticate with the SMTP server
                    client.Authenticate(smtpSettings["Username"], smtpSettings["Password"]);

                    await client.SendAsync(message);
                }
                catch (Exception ex)
                {
                    // Handle the exception (logging, etc.)
                    throw new InvalidOperationException("Failed to send email.", ex);
                }
                finally
                {
                    await client.DisconnectAsync(true);
                    client.Dispose();
                }*/
            }
        }
    }
}
