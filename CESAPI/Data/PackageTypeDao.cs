using CESAPI.Context;
using CESAPI.Model;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Linq;

namespace CESAPI.Data
{
    public class PackageTypeDao
    {
        private IServiceScopeFactory _serviceScopeFactory;
        public PackageTypeDao(IServiceScopeFactory serviceScopeFactory) 
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public List<PackageType> GetAllPackageTypes()
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var routingContext = scope.ServiceProvider.GetRequiredService<RoutingContext>();
                return routingContext.PackageTypes.ToList();
            }
        }

        public PackageType GetPackageType(int id)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var routingContext = scope.ServiceProvider.GetRequiredService<RoutingContext>();
                return routingContext.PackageTypes.Where(p => p.PackageTypeID == id).FirstOrDefault();
            }
        }

        public PackageType GetPackageType(string name)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var routingContext = scope.ServiceProvider.GetRequiredService<RoutingContext>();
                return routingContext.PackageTypes.Where(p => p.PackageTypeName == name).FirstOrDefault();
            }
        }

        public void AddPackageType(PackageType packageType)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var routingContext = scope.ServiceProvider.GetRequiredService<RoutingContext>();
                routingContext.Add(packageType);
                routingContext.SaveChanges();
            }
        }
    }
}
