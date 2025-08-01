using SendGrid;
using SendGrid.Helpers.Mail;
using Microsoft.Extensions.Configuration;

namespace WebAPI.Services
{
    public class SendGridEmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;

        public SendGridEmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            var apiKey = _configuration["SendGrid:ApiKey"];
            var fromEmail = _configuration["SendGrid:FromEmail"];
            var fromName = _configuration["SendGrid:FromName"];

            if (string.IsNullOrEmpty(apiKey) || string.IsNullOrEmpty(fromEmail))
            {
                return;
            }

            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(fromEmail, fromName);
            var to = new EmailAddress(toEmail);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, message, message);
            try
            {
                await client.SendEmailAsync(msg);
            }
            catch
            {
                // Ignore send failures
            }
        }
    }
}
