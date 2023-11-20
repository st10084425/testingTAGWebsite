using System.Threading.Tasks;


namespace TAG_website
{
    public interface IEmailService
    {
        Task SendFAQQuestionsAsync(string toEmail, string subject, string message);
    }
}

