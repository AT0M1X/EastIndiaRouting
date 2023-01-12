using EIT.DTOs;
using System;

namespace EIT.Service
{
    public class FindRouteService
    {
        private readonly CityService _cityService;
        private readonly PackageTypeService _packageTypeService;
        public FindRouteService(CityService cityService, PackageTypeService packageTypeService)
        {
            _cityService = cityService;
            _packageTypeService = packageTypeService;
        }

        public void FindRoutes(FindRouteDto findRouteDto)
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
        }
    }
}
