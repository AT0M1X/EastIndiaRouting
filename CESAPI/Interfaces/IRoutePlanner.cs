using CESAPI.DTOs;
using CESAPI.Model;

namespace CESAPI.Interfaces
{
    public interface IRoutePlanner
    {
        public RouteResult GetRoute(int from, int to, FindRouteDto findRouteDto);
    }
}
