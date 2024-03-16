
using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;
using static System.Net.WebRequestMethods;
using Microsoft.Extensions.Configuration;

namespace SendEmailApp.Service.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;
        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        private string GenerateOtp(int length)
        {
            var randomGenerator = new Random();
            string otp = string.Empty;
            for (int i = 0; i < length; i++)
            {
                otp += randomGenerator.Next(0, 9).ToString();
            }
            return otp;
        }

        public bool SendEmail(String EmailRecieveUser, String UserNameCustomer, String HostContactName, String HostPhoneNumber)
        {
            try
            {
                var emailBodyTemplate = _config.GetSection("EmailSetting")?["EmailBody"];
                emailBodyTemplate = emailBodyTemplate.Replace("{WINNER_NAME}", UserNameCustomer);
                emailBodyTemplate = emailBodyTemplate.Replace("{PHONE_NUMBER}", HostContactName);
                var emailBody = emailBodyTemplate.Replace("{HOST_NAME}", HostPhoneNumber);

                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailSetting")?["EmailHost"]));
                email.To.Add(MailboxAddress.Parse(EmailRecieveUser));
                email.Subject = _config.GetSection("EmailSetting")?["Subject"];
                email.Body = new TextPart(TextFormat.Html)
                {
                    Text = emailBody
                };

                using var smtp = new SmtpClient();
                smtp.Connect(_config.GetSection("EmailSetting")?["EmailHost"], 587, SecureSocketOptions.StartTls);
                smtp.Authenticate(_config.GetSection("EmailSetting")?["EmailUsername"], _config.GetSection("EmailSetting")?["EmailPassword"]);
                smtp.Send(email);
                smtp.Disconnect(true);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
