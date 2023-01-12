using EIT.Model;

namespace EIT.Interfaces
{
    public interface IIntegrationService
    {
        public RouteIntegrationResponse GetRoute(RouteIntegrationRequest routeIntegrationRequest);
    }
}
