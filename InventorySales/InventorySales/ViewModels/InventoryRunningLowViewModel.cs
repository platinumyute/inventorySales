using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventorySales.ViewModels
{
     public class InventoryRunningLowViewModel
     {
          public int ProductId { get; set; }
          public string ProductName { get; set; }
          public string ProductDescription { get; set; }
          public int UnitsAvailable { get; set; }
          public InventoryRunningLowViewModel(int productId, string productName, string productDescription, int unitsAvailable)
          {
               ProductId = productId;
               ProductName = productName;
               ProductDescription = productDescription;
               UnitsAvailable = unitsAvailable;
          }
     }
}