using EIT.DTOs;
using EIT.Model;

namespace EIT.Interfaces
{
    public interface IExternalRouteService
    {
        public RouteIntegrationResponse GetExternalRoute(FindRouteDto findRouteDto);
    }
}
