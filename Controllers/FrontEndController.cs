using EIT.DTOs;
using EIT.Model;
using EIT.Model.Configuration;
using EIT.Service;
using Microsoft.AspNetCore.Http;
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
        private readonly PackageTypeService _packageTypeService;
        private readonly WeightClassService _weightClassService;
        private readonly RouteService _routeService;
        private readonly AuthenticateService _authenticateService;


        public FrontEndController(
            ILogger<FrontEndController> logger, 
            CityService cityService, 
            PackageTypeService packageTypeService,
            WeightClassService weightClassService,
            RouteService routeService,
            AuthenticateService authenticateService
            )
        {
            _logger = logger;
            _cityService = cityService;
            _packageTypeService = packageTypeService;
            _weightClassService = weightClassService;
            _routeService = routeService;
            _authenticateService = authenticateService;
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
    }
}
