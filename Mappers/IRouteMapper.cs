using EIT.DTOs;
using System.Collections.Generic;

namespace EIT.Mappers
{
    public interface IRouteMapper
    {
        public RouteDto MapRouteModelToDto();

        public List<RouteDto> MapRouteModelsToDtos();
    }
}
