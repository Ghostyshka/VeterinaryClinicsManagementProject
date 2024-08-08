using Domain.Models.Dtos; 
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;
using Contracts;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;


namespace Service;

public class MailService : IMailService
{
    private readonly EmailSettings _emailSettings;
    private readonly ILogger<MailService> _logger;

    public MailService(
        IOptions<EmailSettings> emailSettings,
        ILogger<MailService> logger)
    {
        _emailSettings = emailSettings.Value;
        _logger = logger;
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
            _logger.LogError(ex, "Failed to send email to {ToEmail}", mail.ToEmail); return new StatusCodeResult(500);
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
            _logger.LogError(ex, "Failed to send welcome email to {Email}", email);
            throw;
        }
    }
}