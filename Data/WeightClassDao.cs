using EIT.Context;
using EIT.Model;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Linq;

namespace EIT.Data
{
    public class WeightClassDao
    {
        private IServiceScopeFactory _serviceScopeFactory;
        public WeightClassDao(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public List<WeightClass> GetAllWeightClasses()
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var routingContext = scope.ServiceProvider.GetRequiredService<RoutingContext>();
                return routingContext.WeightClasses.ToList();
            }
        }

        public WeightClass GetWeightClass(int id)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var routingContext = scope.ServiceProvider.GetRequiredService<RoutingContext>();
                return routingContext.WeightClasses.Where(w => w.WeightClassID == id).FirstOrDefault();
            }
        }


        public WeightClass GetWeightClass(int minimumWeight, int maximumWeight)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var routingContext = scope.ServiceProvider.GetRequiredService<RoutingContext>();
                return routingContext.WeightClasses.Where(w => w.MinimumWeight == minimumWeight && w.MaximumWeight == maximumWeight).FirstOrDefault();
            }
        }

        public void AddWeightClass(WeightClass weightClass)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var routingContext = scope.ServiceProvider.GetRequiredService<RoutingContext>();
                routingContext.Add(weightClass);
                routingContext.SaveChanges();
            }
        }
    }
}
