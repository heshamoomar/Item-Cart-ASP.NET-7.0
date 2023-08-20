using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;

namespace WebApplication2.Models
{
    public class clsEmailConfirm : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var fMail = "";
            var fPassword = "";

            var Msg = new MailMessage();
            Msg.From = new MailAddress(fMail);
            Msg.Subject = subject;
            Msg.To.Add(email);
            Msg.Body = $"<html><body>{htmlMessage}</body></html>";
            Msg.IsBodyHtml = true;

            var smtpClint = new SmtpClient("smtp.gmail.com")
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(fMail, fPassword),
                Port = 587
            };

            smtpClint.Send(Msg);
            return Task.CompletedTask;
        }
    }
}