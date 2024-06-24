using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace VetClinic.Core.Repositories.Base;

public abstract class BaseController : Controller
{
    protected readonly IConfiguration _configuration;
    protected readonly ILogger _logger;

    protected BaseController(IConfiguration configuration, ILogger logger)
    {
        _configuration = configuration;
        _logger = logger;
    }
}