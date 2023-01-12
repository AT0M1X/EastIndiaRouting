using EIT.DTOs;
using EIT.Model;
using System.Collections.Generic;

namespace EIT.Mappers
{
    public interface IRouteMapper
    {
        public RouteDto MapRouteModelToDto(Route route, List<City> cities);

        public List<RouteDto> MapRouteModelsToDtos(List<Route> routes, List<City> cities);
    }
}
