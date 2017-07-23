using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventorySales.Common
{
     public static class commonValues
     {
          public static int MinimumInventoryUnitsBeforeNotification
          {
               get
               {
                    int num = 100;
                    return num;
               }
          }
     }
}