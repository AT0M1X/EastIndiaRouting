using EIT.Model.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EIT.Controllers
{
    [ApiController]
    [Route("reactclientconfiguration")]
    public class ClientConfigurationController : ControllerBase
    {
        private readonly ILogger<ClientConfigurationController> _logger;
        private readonly ReactClientConfiguration _clientConfig;

        public ClientConfigurationController(ILogger<ClientConfigurationController> logger, ReactClientConfiguration clientConfig)
        {
            _logger = logger;
            _clientConfig = clientConfig;
        }

        [HttpGet]
        [Route("reactclientconfiguration")]
        public ActionResult<ReactClientConfiguration> HentReactClientConfiguration()
        {
            return Ok(_clientConfig);
        }
    }
}