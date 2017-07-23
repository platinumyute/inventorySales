using InventorySales.Models;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System;

namespace InventorySales.ViewModels
{
     public class ProductAddEditViewModel
     {
    
          public int Id { get; set; }

          [DisplayName("Category")]
          [Required(ErrorMessage ="Please Select a Category")]
          public int CategoryId { get; set; }

          [DisplayName("Brand")]
          [Required(ErrorMessage ="Please Select a Brand")]
          public int BrandId { get; set; }

          [Required(ErrorMessage ="Please enter description")]
          public string Description { get; set; }

          public ProductAddEditViewModel(int id, int categoryId, int brandId, string description)
          {
               Id = id;
               CategoryId = categoryId;
               BrandId = brandId;
               Description = description;
          }

          public ProductAddEditViewModel()
          {

          }
     }
}