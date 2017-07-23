using InventorySales.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventorySales.Models
{
     public class Category
     {
          Repository<Category> repository;
          public int Id { get; set; }
          public string Name { get; set; }
          public bool Exists
          {
               get { return repository.Any(c => c.Name == this.Name); }
          }
          public static IEnumerable<Category> All()
          {
               Category category = new Category();
               return category.repository.All();
          }

          public Category()
          {
               init();
          }

          public Category(string name)
          {
               init();
               Name = name;
          }

          private void init()
          {
               repository = new Repository<Category>();
          }

          public void Save()
          {
               repository.Add(this);
          }
          public void Update()
          {
               repository.Update(this);
          }
          public void Remove()
          {
               repository.Remove(this);
          }

          public static Category GetById(int categoryId)
          {
               Category category = new Category();
              return  category.repository.GetById(categoryId);
          }
     }
}