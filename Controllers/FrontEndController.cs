using EIT.Model.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EIT.Controllers
{
    [ApiController]
    [Route("api")]
    public class FrontEndController : ControllerBase
    {
        private readonly ILogger<FrontEndController> _logger;
        private readonly ApplicationConfiguration _appConfig;
    }
}
