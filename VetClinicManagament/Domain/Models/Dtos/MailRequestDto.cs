﻿namespace Domain.Models.Dtos;

public class MailRequestDto
{
    public string Subject { get; set; } = string.Empty;
    public string ToEmail { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
}