using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventorySales.Models
{
     public class ErrorHelp
     {
          public string Message { get; set; }
          public List<string> Solutions { get; set; }
          public ErrorHelp()
          {
               Solutions = new List<string>();
          }
     }
}