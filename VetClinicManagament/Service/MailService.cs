using Domain.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;
using Contracts;

namespace Service;

public class MailService : IMailService
{
    public async Task<IActionResult> SendMailAsync(MailRequestDto mail)
    {
        try
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("m2bradleygobrrrrrr@gmail.com"));
            email.To.Add(MailboxAddress.Parse(mail.ToEmail));
            email.Subject = mail.Subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = mail.Body };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate("m2bradleygobrrrrrr@gmail.com", "ziacsqmesyohnpee");
            smtp.Send(email);
            smtp.Disconnect(true);
            return new OkResult();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return new StatusCodeResult(500);
        }
    }
}