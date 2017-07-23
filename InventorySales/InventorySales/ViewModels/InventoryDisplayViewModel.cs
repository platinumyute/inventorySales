using InventorySales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventorySales.ViewModels
{
     public class InventoryDisplayViewModel
     {
          public int Id { get; set; }
          public string Category { get; set; }
          public string Brand { get; set; }
          public string Description { get; set; }
          public int Available { get; set; }
          public int Sold { get; set; }
          public int Bought { get; set; }
          public decimal PricePerUnit { get; set; }
          public decimal TotalCost { get; set; }

          public InventoryDisplayViewModel(Inventory inventory)
          {
               Product product = Product.GetById(inventory.ProductId);
               Category category = InventorySales.Models.Category.GetById(product.CategoryId);
               ProductBrand brand = ProductBrand.GetById(product.BrandId);
               Id = inventory.Id;
               Category = category.Name;
               Brand = brand.Name;
               Description = product.Description;
               Available = inventory.UnitsPurchased - inventory.UnitsSold;
               Sold = inventory.UnitsSold;
               Bought = inventory.UnitsPurchased;
               PricePerUnit = inventory.PricePaidPerUnit;
               TotalCost = inventory.UnitsPurchased * inventory.PricePaidPerUnit;
          }
     }
}