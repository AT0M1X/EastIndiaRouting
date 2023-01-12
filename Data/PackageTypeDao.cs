using EIT.Context;
using EIT.Model;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Linq;

namespace EIT.Data
{
    public class PackageTypeDao
    {
        private RoutingContext _routingContext;
        public PackageTypeDao(IServiceScopeFactory serviceScopeFactory) 
        {
            using (var scope = serviceScopeFactory.CreateScope())
            {
                _routingContext = scope.ServiceProvider.GetRequiredService<RoutingContext>();
            }
        }

        public List<PackageType> GetAllPackageTypes()
        {
            return _routingContext.PackageTypes.ToList();
        }

        public PackageType GetPackageType(int id)
        {
            return _routingContext.PackageTypes.Where(p => p.PackageTypeID == id).First();
        }

        public PackageType GetPackageType(string name)
        {
            return _routingContext.PackageTypes.Where(p => p.PackageTypeName == name).First();
        }

        public void AddPackageType(PackageType packageType)
        {
            _routingContext.Add(packageType);
            _routingContext.SaveChanges();
        }
    }
}
