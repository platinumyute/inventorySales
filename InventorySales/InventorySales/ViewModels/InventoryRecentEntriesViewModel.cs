using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventorySales.ViewModels
{
     public class InventoryRecentEntriesViewModel
     {
          public string  ProductName { get; set; }
          public string ProductDescription { get; set; }
          public int UnitsBought { get; set; }
          public int UnitsSold { get; set; }
          public decimal PricePerUnit { get; set; }

          public InventoryRecentEntriesViewModel(string productName, string description, int unitsBought, int unitsSold, decimal pricePerUnit)
          {
               ProductName = productName;
               ProductDescription = description;
               UnitsBought = unitsBought;
               UnitsSold = unitsSold;
               PricePerUnit = pricePerUnit;
          }
     }
}