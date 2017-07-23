using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace InventorySales.Database
{
     public static class ConnectionStrings
     {
          public static string InventorySalesConnection
          {
               get
               {
                    DbConnectionStringBuilder builder = new DbConnectionStringBuilder();
                    builder.Add("Data Source", @"NATHAN\PRACTICESERVER");
                    builder.Add("Initial Catalog", @"InventorySales");
                    // builder.Add("User ID", @"UserName");
                    // builder.Add("Password", @"*******");
                    builder.Add("Integrated Security", "True");
                    return builder.ConnectionString;
               }
          }
     }
}