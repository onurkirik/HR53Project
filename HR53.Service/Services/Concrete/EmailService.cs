using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using HR53.Core.OptionsModel;
using HR53.Service.Services.Abstraction;

namespace HR53.Service.Services.Concrete
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> options)
        {
            _emailSettings = options.Value;
        }

        public async Task SendRegisterEmail(string signInLink, string ToEmail, string password)
        {
            var smtpClient = new SmtpClient();

            smtpClient.Host = _emailSettings.Host;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential(_emailSettings.Email, _emailSettings.Password);
            smtpClient.EnableSsl = true;

            var mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(_emailSettings.Email);
            mailMessage.To.Add(ToEmail);

            mailMessage.Subject = "Localhost | HR53 register transaction is completed.";
            mailMessage.Body = @$"<h4>Your password: {password}.</h4>
                    <p>
                        <a href='{signInLink}'>SignIn Link</a> 
                    </p>";
            mailMessage.IsBodyHtml = true;

            await smtpClient.SendMailAsync(mailMessage);
        }

    }
}
