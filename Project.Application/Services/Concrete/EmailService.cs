using MailKit.Net.Smtp;
using MimeKit;
using Project.Application.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Services.Concrete
{
    public class EmailService : IEmailService
    {
        public EmailService()
        {
            
        }

        public void SendCompanyMailToCreatedEmployee(string mail, string password, string privateMailTosend)
        {
            var EmailToSend = new MimeMessage();
            EmailToSend.From.Add(MailboxAddress.Parse("hrprojectbyteam@gmail.com"));
            EmailToSend.To.Add(MailboxAddress.Parse(privateMailTosend));

            EmailToSend.Subject = "Your Company Account info";
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = $@"
            <!DOCTYPE html>
            <html lang='en'>
            <head>
                <meta charset='UTF-8'>
                <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                <title>Your Account Info</title>
            </head>
            <body>
                <h2>Hello,</h2>
                <p>Here are your account details:</p>
                <ul>
                    <li>Email: {mail}</li>
                    <li>Password: {password}</li>
                </ul>
                <p>Thank you!</p>
            </body>
            </html>";

            using(var emailClient = new SmtpClient())
            {
                emailClient.Connect("stmp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                emailClient.Authenticate("hrproject", "yvfwedarqvcrtpfz");
                emailClient.Send(EmailToSend);
                emailClient.Disconnect(true);
            }


        }
    }
}
