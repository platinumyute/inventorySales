using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventorySales.ViewModels
{
     public class ProductBrandAddEditViewModel
     {
          public int Id { get; set; }
          [Required(ErrorMessage = "Please enter brand name")]
          public string Name { get; set; }
     }
}