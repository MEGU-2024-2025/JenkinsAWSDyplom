using MEGUWebMVC.SMTP;

namespace MEGUWebMVC.Interfaces
{
    public interface ISMTPService
    {
        Task<bool> SendEmailAsync(Message message);
    }
}
