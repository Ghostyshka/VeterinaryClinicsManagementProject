using Microsoft.AspNetCore.Mvc;

namespace VetClinic.Api.Controllers.BaseController;

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