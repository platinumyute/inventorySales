using InventorySales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventorySales.Models
{
     public static class DataLists
     {
          public static IEnumerable<DropDownlistItem> Categories()
          {
               return Category.All().Select(c => new DropDownlistItem(c.Id.ToString(), c.Name));
          }

          public static IEnumerable<DropDownlistItem> ProductBrands(int categoryId)
          {
               IEnumerable<int> brandIds = Product.All(p => p.CategoryId == categoryId).Select(item => item.BrandId);
               var brands = brandIds.Select(brandId => ProductBrand.GetById(brandId))
                    .Select(b => new DropDownlistItem(b.Id.ToString(), b.Name));
               return brands;
          }

          public static IEnumerable<DropDownlistItem> ProductBrandsWithDescription()
          {
               var brandIds = Product.All()
                    .Select(p => p.BrandId).Distinct();

               return brandIds.Select(id => ProductBrand.GetById(id))
                    .Select(c => new DropDownlistItem(c.Id.ToString(), c.Name));
          }

          public static IEnumerable<DropDownlistItem> ProductBrands()
          {
               return ProductBrand.All().Select(c => new DropDownlistItem(c.Id.ToString(), c.Name));
          }

          public static IEnumerable<DropDownlistItem> ProductDescription(int productBrandId)
          {
               if (productBrandId > 0)
               {
                    var items = Product.All().Where(p => p.BrandId == productBrandId)
                              .Select(c => new DropDownlistItem(c.Description, c.Description));
                    return items;
               }
               else
                    return new List<DropDownlistItem>();
          }
     }
}