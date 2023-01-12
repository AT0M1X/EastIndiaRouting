using EIT.DTOs;
using System.Collections.Generic;

namespace EIT.Mappers
{
    public class RouteMapperImpl : IRouteMapper
    {
        public RouteDto MapRouteModelToDto()
        {
            return new RouteDto();
        }

        public List<RouteDto> MapRouteModelsToDtos()
        {
            var routes = new List<RouteDto>();
            return routes;
        }
    }
}
