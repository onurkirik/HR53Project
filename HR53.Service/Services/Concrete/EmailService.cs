using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using HR53.Core.OptionsModel;
using HR53.Service.Services.Abstraction;
using static System.Net.Mime.MediaTypeNames;

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

        public string ConvertToEmail(string firstName, string? middleName, string surname, string? secondSurname)
        {
            var email = $"{firstName}{middleName}.{surname}{secondSurname}@bilgeadamboost.com";
           
            email = email.ToLower();
            email = email.Replace("ü", "u");
            email = email.Replace("ı", "i");
            email = email.Replace("ş", "s");
            email = email.Replace("ç", "c");
            email = email.Replace("ö", "o");

            if (email.Contains(" "))
            {
                email = email.Replace(" ", "");
            }

            return email;
        }

    }
}
