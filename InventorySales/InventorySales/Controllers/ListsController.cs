using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InventorySales.Models;

namespace InventorySales.Controllers
{
     public class ListsController : Controller
     {
          // GET: Lists
          public JsonResult Categories()
          {
               IEnumerable<Category> items = Category.All();
               return Json(items.Select(c=> new { text = c.Name, value = c.Id }), JsonRequestBehavior.AllowGet);
          }

          public JsonResult ProductBrands(int categoryId)
          {
               IEnumerable<int> brandIds = Product.All(p => p.CategoryId == categoryId).Select(item => item.BrandId).Distinct();
               IEnumerable<ProductBrand> brands = brandIds.Select(brandId => ProductBrand.GetById(brandId));
               return Json(brands.Select(c => new { text = c.Name, value = c.Id }), JsonRequestBehavior.AllowGet);
          }
          
          public JsonResult ProductDescription(int brandId)
          {
               IEnumerable<Product> items = Product.All(p => p.BrandId == brandId);
               return Json(items.Select(c => new { text = c.Description, value = c.Description }), JsonRequestBehavior.AllowGet);
          }
     }
}