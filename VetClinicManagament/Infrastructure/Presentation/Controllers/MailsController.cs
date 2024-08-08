using Contracts;
using Domain.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Presentation.Controllers.Base;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MailsController : BaseController
{
    private readonly IMailService _mailService;

    public MailsController(
        IConfiguration configuration,
        ILogger<MailsController> logger,
        IMailService mailService
        ) : base(configuration, logger)
    {
        _mailService = mailService;
    }

    [HttpPost("send")]
    public async Task<IActionResult> SendMail([FromBody] MailRequestDto mail)
    {
        return await _mailService.SendMailAsync(mail);
    }
}