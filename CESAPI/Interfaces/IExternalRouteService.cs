using CESAPI.DTOs;
using CESAPI.Model;

namespace CESAPI.Interfaces
{
    public interface IExternalRouteService
    {
        public RouteIntegrationResponse GetExternalRoute(FindRouteDto findRouteDto);
    }
}
