using InventorySales.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InventorySales.Models
{
     public class Product
     {
          Repository<Product> repository;
        

          public int Id { get; set; }

          public int CategoryId { get; set; }
          protected Category Category { get; set; }
          public int BrandId { get; set; }
          protected ProductBrand Brand { get; set; }
          public string Description { get; set; }

          public Product()
          {
               init();
          }

          public static IEnumerable<Product> All()
          {
               Product product = new Product();
               return product.repository.All();
          }

          internal static IEnumerable<Product> All(Func<Product, bool> filter)
          {
               Product product = new Product();
               return product.repository.All().Where(filter);
          }

          private void init()
          {
               repository = new Repository<Product>();
          }

          public void Save()
          {
               repository.Add(this);
          }

          public static Product GetById(int productId)
          {
               Product product = new Product();
               return product.repository.GetById(productId);
          }

      
          public void Update()
          {
               repository.Update(this);
          }
          public void Remove()
          {
               repository.Remove(this);
          }
          public bool Exists
          {
               get
               {
                    return Any(p => p.BrandId == this.BrandId && p.Description == this.Description);
               }
          }

          public bool Any(Func<Product, bool> filter)
          {
               Product p = new Product();
               return p.repository.Any(filter);
          }
     }
}