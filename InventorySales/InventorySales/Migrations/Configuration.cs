namespace InventorySales.Migrations
{
     using Models;
     using System;
     using System.Data.Entity;
     using System.Data.Entity.Migrations;
     using System.Linq;

     internal sealed class Configuration : DbMigrationsConfiguration<InventorySales.Database.InventorySalesDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
          
        protected override void Seed(InventorySales.Database.InventorySalesDb context)
        {
               //  This method will be called after migrating to the latest version.

               //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
               //  to avoid creating duplicate seed data. E.g.
               //
               //    context.People.AddOrUpdate(
               //      p => p.FullName,
               //      new Person { FullName = "Andrew Peters" },
               //      new Person { FullName = "Brice Lambson" },
               //      new Person { FullName = "Rowan Miller" }
               //    );
               //
               Category c1 = new Category() { Name = "Soft Drinks" };
               Category c2 = new Category() { Name = "Grocery" };
               Category c3 = new Category() { Name = "Nutritional Drinks" };
               context.Categories.AddOrUpdate(c1, c2, c3);
               context.SaveChanges();

               ProductBrand pb1 = new ProductBrand() { Name = "Pepsi" };
               ProductBrand pb2 = new ProductBrand() { Name = "Coke" };
               ProductBrand pb3 = new ProductBrand() { Name = "Ensure" };
               context.ProductBrands.AddOrUpdate(pb1, pb2, pb3);
               context.SaveChanges();

               Product p1 = new Product() { CategoryId = c1.Id, BrandId = pb1.Id, Description = "32 oz" };
               Product p2 = new Product() { CategoryId = c2.Id, BrandId = pb1.Id, Description = "20 oz" };
               context.Products.AddOrUpdate(p1, p2);
               context.SaveChanges();

          }
     }
}
