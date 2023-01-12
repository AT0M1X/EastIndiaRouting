using EIT.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace EIT.Context
{
    public class RoutingContext : DbContext
    {
        public RoutingContext(DbContextOptions<RoutingContext> options) : base(options) { }

        public DbSet<City> Cities { get; set; }
        public DbSet<PackageType> PackageTypes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WeightClass> WeightClasses { get; set; }
    }
}