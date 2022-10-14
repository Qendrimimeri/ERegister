using Application.Models;

namespace Application.Repository.IRepository
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequestModel mailRequest);
    }
}
