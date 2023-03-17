namespace HR53.Service.Services.Abstraction
{
    public interface IEmailService
    {
        Task SendRegisterEmail(string signInLink, string ToEmail, string password);
    }
}
