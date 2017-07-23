using InventorySales.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventorySales.ViewModels
{
     public class InventoryEditViewModel
     {
          public int Id { get; set; }


          [DisplayName("Brand")]
          [Required(ErrorMessage="Please select brand")]
          public int BrandId { get; set; }


          [Required(ErrorMessage="Please select category")]
          public int CategoryId { get; set; }


          [Required(ErrorMessage="Please select description")]
          public string Description { get; set; }


          [DisplayName("Units Purchased")]
          [Required(ErrorMessage="Please enter units purchased")]
          public int UnitsPurchased { get; set; }


          [DisplayName("Units Sold")]
          public int UnitsSold { get; set; }

          
          [DisplayName("Price Paid Per Unit")]
          [Required(ErrorMessage="Please enter price paid per unit")]
          public decimal PricePaidPerUnit { get; set; }

     }
}