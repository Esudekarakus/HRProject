using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using Project.Application.DTOs;
using Project.Application.Features.CQRS.Commands.AccountCommands;
using Project.Application.Services.Abstract;
using Project.WebApi.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Services.Concrete
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings emailSettings;

        public EmailService(IOptions<EmailSettings> options)
        {
            this.emailSettings = options.Value;
        }

        public async Task SendCompanyMailToCreatedEmployee(string mail, string password, string privateMailTosend)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(emailSettings.Email);
            email.To.Add(MailboxAddress.Parse(privateMailTosend));
            email.Subject = "Your Company Account info";
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
            email.Body = bodyBuilder.ToMessageBody();

            using var smtp = new SmtpClient();
            smtp.Connect(emailSettings.Host, emailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(emailSettings.Email, emailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);


        }

        public async Task<bool> SendVerificationCodeToUser(ForgotPasswordCommand command)
        {

            try
            {
                var random = new Random();
                var verificationCode = new string(Enumerable.Repeat("0123456789", 6) // Use "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ" for alphanumeric
                                                  .Select(s => s[random.Next(s.Length)]).ToArray());

                GeneratedVerifyCode code = new(verificationCode);

                var email = new MimeMessage();
                email.Sender = MailboxAddress.Parse(emailSettings.Email);
                email.To.Add(MailboxAddress.Parse(command.privateMail));
                email.Subject = "Verification Code";
                var bodyBuilder = new BodyBuilder();
                bodyBuilder.HtmlBody = $@"
                <!DOCTYPE html>
                <html lang='en'>
                <head>
                    <meta charset='UTF-8'>
                    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                    <title>Verification Code</title>
                </head>
                <body>
                    <h2>Hello,</h2>
                    <p>Here is your verification code:</p>
                    <ul>
                        <li>Email: {verificationCode}</li>
                    </ul>
                    <p>Thank you!</p>
                </body>
                </html>";
                email.Body = bodyBuilder.ToMessageBody();

                using var smtp = new SmtpClient();
                smtp.Connect(emailSettings.Host, emailSettings.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(emailSettings.Email, emailSettings.Password);
                await smtp.SendAsync(email);
                smtp.Disconnect(false);

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ;
            }



        }
    }
}
