namespace HR53.Service.Services
{
    public interface IEmailService
    {
        Task SendResetEmail(string resetEmailLink, string ToEmail);

    }
}
