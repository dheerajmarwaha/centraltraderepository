using Microsoft.EntityFrameworkCore;
using SOC.GEN.DealService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOC.GEN.DealService.DBContexts
{
    public class DealContext : DbContext
    {
        public DealContext(DbContextOptions<DealContext> options) : base(options)
        {

        }

        public DbSet<Deal> Deals { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Currency> Currencies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asset>().HasData(
                new Asset
                {
                    Id = 1,
                    asset_nm = "Rate"
                },
                new Asset
                {
                    Id = 2,
                    asset_nm = "Forex"
                }
                );

            modelBuilder.Entity<Currency>().HasData(
                new Currency
                {
                    Id = 1,
                    currency_nm = "Rs",
                    currency_symbol = "Rs"
                },
               new Currency
               {
                   Id = 2,
                   currency_nm = "Dollar",
                   currency_symbol = "$"
               });
        }
    }
}
