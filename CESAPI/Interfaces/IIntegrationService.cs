using CESAPI.Model;

namespace CESAPI.Interfaces
{
    public interface IIntegrationService
    {
        public RouteIntegrationResponse GetRoute(RouteIntegrationRequest routeIntegrationRequest);
    }
}
