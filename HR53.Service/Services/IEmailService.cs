namespace HR53.Service.Services
{
    public interface IEmailService
    {
        Task SendRegisterEmail(string signInLink, string ToEmail, string password);
    }
}
