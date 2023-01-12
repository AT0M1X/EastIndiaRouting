using EIT.DTOs;
using EIT.Interfaces;
using EIT.Model;
using System;

namespace EIT.Service
{
    public class FindRouteService
    {
        private readonly CityService _cityService;
        private readonly PackageTypeService _packageTypeService;
        private readonly IRoutePlanner _routePlanner;
        public FindRouteService(CityService cityService, PackageTypeService packageTypeService, IRoutePlanner routePlanner)
        {
            _cityService = cityService;
            _packageTypeService = packageTypeService;
            _routePlanner = routePlanner;
        }

        public RouteResult FindRoutes(FindRouteDto findRouteDto)
        {
            var origin = _cityService.GetCity(findRouteDto.From);
            if (origin == null)
            {
                throw new ArgumentException();
            }

            var destination = _cityService.GetCity(findRouteDto.To);
            if (destination == null)
            {
                throw new ArgumentException();
            }

            var packageType = _packageTypeService.GetPackageType(findRouteDto.PackageType);
            if (packageType == null)
            {
                throw new ArgumentException();
            }

            return _routePlanner.GetRoute(origin.Id, destination.Id, findRouteDto);
        }
    }
}
