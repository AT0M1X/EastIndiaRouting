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
        public RouteService(IRouteMapper routeMapper, RouteDao routeDao)
        {
            _routeMapper = routeMapper;
            _routeDao = routeDao;
        }

        public List<RouteDto> GetInternalRoutes()
        {
            var routeModels = _routeDao.GetAllRoutes();
            return _routeMapper.MapRouteModelsToDtos(routeModels);
        }
    }
}
