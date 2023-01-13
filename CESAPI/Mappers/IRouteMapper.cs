using CESAPI.DTOs;
using CESAPI.Model;
using System.Collections.Generic;

namespace CESAPI.Mappers
{
    public interface IRouteMapper
    {
        public RouteDto MapRouteModelToDto(Model.Route route, List<City> cities);

        public List<RouteDto> MapRouteModelsToDtos(List<Model.Route> routes, List<City> cities);
    }
}
