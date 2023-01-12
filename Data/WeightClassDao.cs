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
        private RoutingContext _routingContext;
        public WeightClassDao(IServiceScopeFactory serviceScopeFactory) 
        {
            using (var scope = serviceScopeFactory.CreateScope())
            {
                _routingContext = scope.ServiceProvider.GetRequiredService<RoutingContext>();
            }
        }

        public List<WeightClass> GetAllWeightClasses()
        {
            return _routingContext.WeightClasses.ToList();
        }

        public WeightClass GetWeightClass(int id)
        {
            return _routingContext.WeightClasses.Where(w => w.WeightClassID == id).FirstOrDefault();
        }

        public WeightClass GetWeightClass(int minimumWeight, int maximumWeight)
        {
            return _routingContext.WeightClasses.Where(w => w.MinimumWeight == minimumWeight && w.MaximumWeight == maximumWeight).FirstOrDefault();
        }

        public void AddWeightClass(WeightClass weightClass)
        {
            _routingContext.Add(weightClass);
            _routingContext.SaveChanges();
        }
    }
}
