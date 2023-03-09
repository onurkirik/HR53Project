namespace HR53.Web.Services
{
    public interface IEmailService
    {
        Task SendResetEmail(string resetEmailLink, string ToEmail);

    }
}
