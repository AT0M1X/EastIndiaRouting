using CESAPI.DTOs;
using CESAPI.Model;
using CESAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace CESAPI.Controllers
{
    [ApiController]
    [Route("api")]
    public class FrontEndController : ControllerBase
    {
        //private readonly ILogger<FrontEndController> _logger;
        private readonly CityService _cityService;
        private readonly PackageTypeService _packageTypeService;
        private readonly WeightClassService _weightClassService;
        private readonly RouteService _routeService;
        private readonly AuthenticateService _authenticateService;
        private readonly FindRouteService _findRouteService;

        public FrontEndController(
            CityService cityService,
            PackageTypeService packageTypeService,
            WeightClassService weightClassService,
            RouteService routeService,
            AuthenticateService authenticateService,
            FindRouteService findRouteService
            )
        {
            _cityService = cityService;
            _packageTypeService = packageTypeService;
            _weightClassService = weightClassService;
            _routeService = routeService;
            _authenticateService = authenticateService;
            _findRouteService  = findRouteService;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("/cities", Name = nameof(GetCities))]
        public IEnumerable<CityDto> GetCities()
        {
            return _cityService.GetCities();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("/packagetypes", Name = nameof(GetPackageTypes))]
        public IEnumerable<PackageTypeDto> GetPackageTypes()
        {
            return _packageTypeService.GetPackageTypes();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("/weightclasses", Name = nameof(GetWeightClasses))]
        public IEnumerable<WeightClassDto> GetWeightClasses()
        {
            return _weightClassService.GetWeightClasses();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("/internalroutes", Name = nameof(GetInternalRoutes))]
        public IEnumerable<RouteDto> GetInternalRoutes()
        {
            return _routeService.GetInternalRoutes();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("/authenticate", Name = nameof(Authenticate))]
        public bool Authenticate([FromQuery] AuthenticateRequest authenticateRequest)
        {
            return _authenticateService.Authenticate(authenticateRequest.Username, authenticateRequest.Password);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("/findInternalRoute", Name = nameof(GetInternalRoute))]
        public IActionResult GetInternalRoute(string from, string to, int weight, int length, int width, int height, string packageType, DateTime arrivalTime, string currency, bool recommended)
        {

            try
            {
                var route = _findRouteService.FindRoutes(new FindRouteDto
                {
                    From = from,
                    To = to,
                    Height = height,
                    Length = length,
                    Weight = weight,
                    Width = width,
                    PackageType = packageType,
                    SendTime = arrivalTime,
                    Currency = currency,
                    Recommended = recommended
                });

                if (route != null)
                {
                    return Ok(route);
                }
                return NoContent();

            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            
        }
    }
}
