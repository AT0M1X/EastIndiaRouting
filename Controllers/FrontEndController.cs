using EIT.DTOs;
using EIT.Model.Configuration;
using EIT.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace EIT.Controllers
{
    [ApiController]
    [Route("api")]
    public class FrontEndController : ControllerBase
    {
        private readonly ILogger<FrontEndController> _logger;
        private readonly CityService _cityService;

        public FrontEndController(ILogger<FrontEndController> logger, CityService cityService)
        {
            _logger = logger;
            _cityService = cityService;
        }

        [HttpGet("/cities", Name = nameof(GetCities))]
        public IEnumerable<CityDto> GetCities()
        {
            return _cityService.GetCities();
        }
    }
}
