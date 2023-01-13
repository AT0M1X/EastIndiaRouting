using System.Collections.Generic;
using System.Data;
using CESAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace CESAPI.Context 
{
    public class RoutingContext : DbContext
    {
        public RoutingContext(DbContextOptions<RoutingContext> options) : base(options) { }

        public DbSet<City> Cities { get; set; }
        public DbSet<PackageType> PackageTypes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Model.Route> Routes { get; set; }
        public DbSet<ServiceAccount> ServiceAccounts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WeightClass> WeightClasses { get; set; }
    }
}
