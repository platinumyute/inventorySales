using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InventorySales.Repository;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventorySales.Models
{
     public class Inventory
     {
          Repository<Inventory> repository;
          public bool Exists
          {
               get { return repository.Any(i => i.ProductId == this.ProductId); }
          }
          public int Id { get; set; }
          public int ProductId { get; set; }
          protected Product Product { get; set; }
          public int UnitsPurchased { get; set; }

          public static IEnumerable<Inventory> All()
          {
               Inventory inventory = new Inventory();
               return inventory.repository.All();
          }
          public static IEnumerable<Inventory> All(Func<Inventory, bool> filter)
          {
               Inventory inventory = new Inventory();
               return inventory.repository.All(filter);
          }
          public int UnitsSold { get; set; }
          public decimal PricePaidPerUnit { get; set; }
          public decimal TotalCost {
               get
               {
                    return UnitsPurchased * PricePaidPerUnit;
               }
          }

          public static Inventory GetById(int id)
          {
               Inventory inventory = new Inventory();
               return inventory.repository.GetById(id);
          }

          public Inventory()
          {
               init();
          }

          private void init()
          {
               repository = new Repository<Inventory>();
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

          
     }
}