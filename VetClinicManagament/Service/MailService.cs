using Domain.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;
using Contracts;
using Microsoft.Extensions.Options;

namespace Service;

public class MailService : IMailService
{
    private readonly EmailSettingsDto _emailSettings;

    public MailService(IOptions<EmailSettingsDto> emailSettings)
    {
        _emailSettings = emailSettings.Value;
    }

    public async Task<IActionResult> SendMailAsync(MailRequestDto mail)
    {
        try
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_emailSettings.FromEmail));
            email.To.Add(MailboxAddress.Parse(mail.ToEmail));
            email.Subject = mail.Subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = mail.Body };

            using var smtp = new SmtpClient();
            smtp.Connect(_emailSettings.SmtpServer, _emailSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate(_emailSettings.UserName, _emailSettings.Password);
            smtp.Send(email);
            smtp.Disconnect(true);
            return new OkResult();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString()); //rewrite
            return new StatusCodeResult(500);
        }
    }
    public async Task SendWelcomeEmailAsync(string email, string firstName)
    {
        var templatePath = Path.Combine("..\\..\\VetClinicManagament\\VetClinicManagament\\", "Templates", "WelcomeTemplate.html");
        var emailBody = await File.ReadAllTextAsync(templatePath);
        emailBody = emailBody.Replace("{{UserName}}", firstName);

        var mailRequest = new MailRequestDto
        {
            ToEmail = email,
            Subject = "Welcome to VetClinic",
            Body = emailBody
        };

        try
        {
            await SendMailAsync(mailRequest);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}