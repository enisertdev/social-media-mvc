using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace NewExcite.Business.Services
{
    public class EmailService
    {
        private readonly string hostEmail;
        private readonly string hostPassword;

        public EmailService(IConfiguration configuration)
        {
            hostEmail = configuration["EmailCredentials:Email"];
            hostPassword = configuration["EmailCredentials:Password"];
        }
        public async Task SendEmailAsync(string to, string subject, string body)
        {
            using (var client = new SmtpClient("smtp.zoho.eu", 587))
            {
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(hostEmail, hostPassword);
                var mailMessage = new MailMessage()
                {
                    From = new MailAddress(hostEmail),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };
                mailMessage.To.Add(to);
                try
                {
                    await client.SendMailAsync(mailMessage);

                }
                catch (Exception)
                {
                    throw new ApplicationException("E-posta gönderme işlemi sırasında bir hata oluştu. Lütfen daha sonra tekrar deneyin.");
                }
            }

        }
    }
}
