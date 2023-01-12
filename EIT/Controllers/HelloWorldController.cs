using EIT.Model;
using EIT.Model.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace EIT.Controllers
{
    [ApiController]
    [Route("api")]
    public class HelloWorldController : ControllerBase
    {
        private readonly ILogger<HelloWorldController> _logger;
        private readonly ApplicationConfiguration _appConfig;

        public HelloWorldController(ILogger<HelloWorldController> logger, ApplicationConfiguration appConfig)
        {
            _logger = logger;
            _appConfig = appConfig;
        }

        [HttpGet("helloworld/{target}")]
        public HelloWorld HentHelloWorld(string target)
        {
            var helloWorld = new HelloWorld()
            {
                Response = $"Hello, {target}"
            };

            _logger.LogInformation($"Eksempel på logging, og config object injected under startup: {_appConfig.Name}");

            return helloWorld;
        }

        [HttpGet("helloworldasync/{target}")]
        public async Task<ActionResult<HelloWorld>> HentHelloWorldAsync(string target)
        {
            var helloWorld = new HelloWorld()
            {
                Response = $"Hello, {target}"
            };

            // Indsat for an ungå brok over manglende async
            var dummySletMig = await  Task.FromResult(false); 

            _logger.LogInformation($"Eksempel på logging, og config object injected under startup: {_appConfig.Name}");

            return Ok(helloWorld);

            // Andre eksempler
            // return NotFound(); for tomt/null resultat.
        }
    }
}
