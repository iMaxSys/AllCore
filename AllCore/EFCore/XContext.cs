using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies;

using AllCore.Models;

namespace AllCore.EFCore
{
    /*
        Add-Migration v1.0.0
        Update-Database v1.0.0
    */

    /// <summary>
    /// XContext
    /// </summary>
    public class XContext : DbContext
    {
        public DbSet<Catalog> Catalogs { get; set; }
        public DbSet<Goods> Goods { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Activity> Activities { get; set; }

        public XContext(DbContextOptions<XContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            //builder.UseLazyLoadingProxies();
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CatalogConfiguration());
            modelBuilder.ApplyConfiguration(new GoodsConfiguration());
            modelBuilder.ApplyConfiguration(new MemberConfiguration());
            modelBuilder.ApplyConfiguration(new CartConfiguration());
            modelBuilder.ApplyConfiguration(new ActivityConfiguration());
            modelBuilder.ApplyConfiguration(new ActivityItemConfiguration());
        }
    }
}
