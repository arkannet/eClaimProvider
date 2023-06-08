using eClaimProvider.Application.Requests.Mail;
using System.Threading.Tasks;

namespace eClaimProvider.Application.Interfaces.Services
{
    public interface IMailService
    {
        Task SendAsync(MailRequest request);
    }
}