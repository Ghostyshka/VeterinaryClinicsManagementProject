﻿using Domain.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Contracts;

public interface IMailService
{
    Task<IActionResult> SendMailAsync(MailRequestDto mail);
}