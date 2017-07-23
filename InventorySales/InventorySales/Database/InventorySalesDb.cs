using InventorySales.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace InventorySales.Database
{
     public class InventorySalesDb: DbContext
     {
          public InventorySalesDb(string connectionString):
               base(connectionString)
          {
          }
          public DbSet<Inventory> Inventory { get; set; }
          public DbSet<Product> Products { get; set; }
          public DbSet<ProductBrand> ProductBrands { get; set; }
          public DbSet<Category> Categories { get; set; }

          
          protected override void OnModelCreating(DbModelBuilder modelBuilder)
          {
               modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
          }
     }
}