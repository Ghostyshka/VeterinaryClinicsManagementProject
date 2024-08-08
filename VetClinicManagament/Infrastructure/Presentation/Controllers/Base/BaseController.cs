using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Presentation.Controllers.Base;

public abstract class BaseController : ControllerBase
{
    public readonly IConfiguration _configuration;
    public readonly ILogger<BaseController> _logger;
    public BaseController(
        IConfiguration configuration,
        ILogger<BaseController> logger)

    {
        _configuration = configuration;
        _logger = logger;
    }
}