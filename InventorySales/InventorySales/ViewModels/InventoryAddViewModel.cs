using InventorySales.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventorySales.ViewModels
{
     public class InventoryAddViewModel
     {
          public int Id { get; set; }

          [DisplayName("Brand")]
          [Required(ErrorMessage="Please select brand")]
          public int BrandId { get; set; }
          
          [Required(ErrorMessage="Please select description")]
          public string Description { get; set; }

          [DisplayName("Units Purchased")]
          [Required(ErrorMessage="Please enter units purchased")]
          public int UnitsPurchased { get; set; }

          [DisplayName("Units Sold")]
          public int UnitsSold { get; set; }

          [DisplayName("Price Paid Per Unit")]
          [Required(ErrorMessage ="Please enter purchase price")]
          public decimal PricePaidPerUnit { get; set; }
          
     }
}