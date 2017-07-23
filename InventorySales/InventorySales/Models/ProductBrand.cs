using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InventorySales.Repository;

namespace InventorySales.Models
{
     public class ProductBrand
     {
          Repository<ProductBrand> Repository;
          public int Id { get; set; }
          public string Name { get; set; }
          public ProductBrand()
          {
               init(new Repository<ProductBrand>());
          }

          void init(Repository<ProductBrand> repository)
          {
               Repository = repository;
          }

          public static ProductBrand GetById(int brandId)
          {
               ProductBrand product = new ProductBrand();
               return product.Repository.GetById(brandId);
          }

          public void Update()
          {
               Repository.Update(this);
          }

          public void Add()
          {
              Repository.Add(this);
          }
          public void Remove()
          {
              Repository.Remove(this);
          }

          public static IEnumerable<ProductBrand> All()
          {
               ProductBrand brand = new ProductBrand();
               return brand.Repository.All();
          }
          public static IEnumerable<ProductBrand> All(Func<ProductBrand, bool> filter)
          {
               ProductBrand brand = new ProductBrand();
               return brand.Repository.All(filter);
          }

          public bool Exists()
          {
               return Repository.Any(b => b.Name == this.Name) ;
          }
     }
}