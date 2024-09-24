using MailKit.Net.Smtp;
using MimeKit;
using System.Threading.Tasks;
using MailKit.Security;
using DAL.Interface;
using Models.Model;

namespace DAL.Implementation
{
    public class EmailService: IEmailService
    {
        public async Task SendEmailAsync(SendEmailModel emailDetails)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Rachel Brunner", "rachelb2855@gmail.com"));
            message.To.Add(new MailboxAddress("", emailDetails.ToEmail));
            message.Subject = emailDetails.Subject;

            message.Body = new TextPart("html")
            {
                Text = emailDetails.Body
            };

            using (var client = new SmtpClient())
            {
               
                await client.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);

                
                await client.AuthenticateAsync("rachelb2855@gmail.com", "gaeh llzr cqcd ftnq");

               
                await client.SendAsync(message);

                
                await client.DisconnectAsync(true);
            }
        }


    }
}
