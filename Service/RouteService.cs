using EIT.Data;
using EIT.DTOs;
using EIT.Mappers;
using System.Collections.Generic;

namespace EIT.Service
{
    public class RouteService
    {
        private readonly IRouteMapper _routeMapper;
        private readonly RouteDao _routeDao;
        private readonly CityDao _cityDao;
        public RouteService(IRouteMapper routeMapper, RouteDao routeDao, CityDao cityDao)
        {
            _routeMapper = routeMapper;
            _routeDao = routeDao;
            _cityDao = cityDao;
        }

        public List<RouteDto> GetInternalRoutes()
        {
            var routeModels = _routeDao.GetAllRoutes();
            var cityModels = _cityDao.GetAllCities();
            return _routeMapper.MapRouteModelsToDtos(routeModels, cityModels);
        }
    }
}
