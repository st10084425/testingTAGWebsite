using Microsoft.AspNetCore.Identity.UI.Services;

namespace TAG_website
{
    public class EmailService : IEmailService
    {
        private readonly IEmailSender _emailSender;

        public EmailService(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public async Task SendFAQQuestionsAsync(string toEmail, string subject, string message)
        {
            await _emailSender.SendEmailAsync(toEmail, subject, message);
        }
    }
}