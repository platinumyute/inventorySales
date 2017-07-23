using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventorySales.ViewModels
{
     public class ProductRecentEntriesViewModel
     {
          public string Category { get; set; }
          public string ProductName { get; set; }
          public string ProductDescription { get; set; }
          public ProductRecentEntriesViewModel(string category, string productName, string productDescription)
          {
               Category = category;
               ProductName = productName;
               ProductDescription = productDescription;
          }
     }
}