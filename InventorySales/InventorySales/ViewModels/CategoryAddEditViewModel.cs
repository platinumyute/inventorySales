using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using InventorySales.Models;

namespace InventorySales.ViewModels
{
     public class CategoryAddEditViewModel
     {
          public int Id { get; set; }

          [Required(ErrorMessage ="Please enter category name")]
          public string Name { get; set; }
          public CategoryAddEditViewModel(int id, string name)
          {
               Id = id;
               Name = name;
          }

          public CategoryAddEditViewModel()
          {
          }
     }
}