using System;
using System.Collections.Generic;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog.Context;

namespace EIT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientLoggingController : ControllerBase
    {
        private readonly ILogger<ClientLoggingController> log;

        public ClientLoggingController(ILogger<ClientLoggingController> logger)
        {
            log = logger;
            LogContext.PushProperty("LogSource", "ReactClient");
        }

        private object[] GetPropertiesArray(string properties)
        {
            try
            {
                var d = JsonSerializer.Deserialize<Dictionary<string, dynamic>>(properties);
                var propertyValues = new object[d.Count];
                var idx = 0;
                foreach (var key in d.Keys)
                {
                    propertyValues[idx++] = JsonSerializer.Serialize(d[key]);
                }

                return propertyValues;
            }
            catch
            {
                return new object[0];
            }
        }

        /// <summary>
        /// Insert using LogDebug
        /// </summary>
        /// <param name="logging">Logging info</param>
        /// <returns></returns>
        [HttpPost]
        [Route("debug")]
        [Consumes("application/json")]
        public IActionResult Debug(ClientLogging logging)
        {
            try
            {
                log.LogDebug(logging.MessageTemplate, GetPropertiesArray(logging.Properties));
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Insert using LogInformation
        /// </summary>
        /// <param name="logging"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("information")]
        [Consumes("application/json")]
        public IActionResult Information(ClientLogging logging)
        {
            try
            {
                log.LogInformation(logging.MessageTemplate, GetPropertiesArray(logging.Properties));
                return Ok();
            }
            catch (Exception e)
            {
                log.LogWarning($"Returning badrequest, exception caught: {e}");
                return BadRequest();
            }
        }

        /// <summary>
        /// Insert using LogWarning
        /// </summary>
        /// <param name="logging"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("warning")]
        [Consumes("application/json")]
        public IActionResult Warning(ClientLogging logging)
        {
            try
            {
                log.LogWarning(logging.MessageTemplate, GetPropertiesArray(logging.Properties));
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Insert using LogError
        /// </summary>
        /// <param name="logging"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("error")]
        [Consumes("application/json")]
        public IActionResult Error(ClientLogging logging)
        {
            try
            {
                log.LogError(logging.MessageTemplate, GetPropertiesArray(logging.Properties));
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Insert using LogCritical
        /// </summary>
        /// <param name="logging"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("critical")]
        [Consumes("application/json")]
        public IActionResult Critical(ClientLogging logging)
        {
            try
            {
                log.LogCritical(logging.MessageTemplate, GetPropertiesArray(logging.Properties));
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Insert using LogTrace
        /// </summary>
        /// <param name="logging"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("trace")]
        [Consumes("application/json")]
        public IActionResult Trace(ClientLogging logging)
        {
            try
            {
                log.LogTrace(logging.MessageTemplate, GetPropertiesArray(logging.Properties));
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }

    public class ClientLogging
    {
        /// <summary>
        /// Serilog inspired template.
        /// See https://confluence.stil.dk/x/gAXdCw for more info
        /// </summary>
        public string MessageTemplate { get; set; }

        /// <summary>
        /// JSON formatted object with name / value members
        /// </summary>
        public string Properties { get; set; }
    }
}