using EIT.DTOs;
using EIT.Model;
using System.Collections.Generic;

namespace EIT.Mappers
{
    public interface IRouteMapper
    {
        public RouteDto MapRouteModelToDto(Route route);

        public List<RouteDto> MapRouteModelsToDtos(List<Route> routes);
    }
}
