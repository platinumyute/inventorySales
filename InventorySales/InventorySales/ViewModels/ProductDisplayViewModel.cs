using InventorySales.Models;

namespace InventorySales.ViewModels
{
     public class ProductDisplayViewModel
     {
          public int Id { get; set; }
          public string Category { get; set; }
          public string Brand { get; set; }
          public string Description { get; set; }
          public ProductDisplayViewModel(Product product)
          {
               Category category = Models.Category.GetById(product.CategoryId);
               ProductBrand brand = ProductBrand.GetById(product.BrandId);
               Id = product.Id;
               Category = category.Name;
               Brand = brand.Name;
               Description = product.Description;
          }
     }
}