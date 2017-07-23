using InventorySales.Common;
using InventorySales.Models;
using InventorySales.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventorySales.Controllers
{
     public class ProductController : Controller
     {
          public ActionResult Index()
          {
               return RedirectToAction("display");
          }
          
          public ActionResult SubMenu()
          {
               return View();
          }

          //display
          public ActionResult Display(int? pageRequested)
          {
               IEnumerable<Product> QueryProducts = Product.All();

               //pagination
               pageRequested = pageRequested ?? 1;
               Pagination<Product> pagination = new Pagination<Product>(QueryProducts, (int)pageRequested);
               ViewBag.TotalPages = pagination.TotalPages;
               //pagination end

               //sets model
               IEnumerable<ProductDisplayViewModel> model = pagination.GetPaginatedResult().Select(p => new ProductDisplayViewModel(p));
               return View(model);
          }

          //add
          [Authorize, HttpPost]
          public ActionResult Add(ProductAddEditViewModel formData)
          {
               Product product = new Product()
               {
                    BrandId = formData.BrandId,
                    CategoryId = formData.CategoryId,
                    Description = formData.Description
               };

               if (!product.Exists)
               {
                    product.Save();
                    return RedirectToAction("Add");
               }
               else
               {
                    string message = "An Error occured when trying to add new product.";
                    List<string> solutions = new List<string>();
                    solutions.Add("Product Already exists");
                    ErrorHelp error = new ErrorHelp()
                    {
                         Message = message,
                         Solutions = solutions
                    };

                    return View("_ErrorView", error);
               }
          }

          [HttpGet]
          public ActionResult Add()
          {
               ViewBag.Categories = DataLists.Categories();
               ViewBag.Brands = DataLists.ProductBrands();
               return View(new ProductAddEditViewModel());
          }

          //edit
          [Authorize, HttpGet]
          public ActionResult Edit(int id)
          {
               ViewBag.Categories = DataLists.Categories();
               ViewBag.Brands = DataLists.ProductBrands();
               Product product = Product.GetById(id);
               ProductAddEditViewModel model = new ProductAddEditViewModel(product.Id, product.CategoryId, product.BrandId, product.Description);
               return View(model);
          }

          [Authorize, HttpPost]
          public ActionResult Edit(Product formData)
          {
               Product product = new Product()
               {
                    Id = formData.Id,
                    BrandId = formData.BrandId,
                    CategoryId = formData.CategoryId,
                    Description = formData.Description,
               };
               if (!product.Exists)
               {
                    product.Update();
                    return RedirectToAction("Display");
               }
               else
               {
                    string message = "An Error occured when trying to edit product.";
                    List<string> solutions = new List<string>();
                    solutions.Add("Product Already exists");
                    ErrorHelp error = new ErrorHelp()
                    {
                         Message = message,
                         Solutions = solutions
                    };

                    return View("_ErrorView", error);
               }
          }

          //delete
          [Authorize]
          public ActionResult Delete(int id)
          {
               Product product = Product.GetById(id);
               try
               {
                    product.Remove();
                    return RedirectToAction("Display");
               }
               catch
               {
                    string message = "An Error occured when trying to delete product.";
                    List<string> solutions = new List<string>();
                    solutions.Add("Ensure that the product you're trying to delete is not a part of your inventory list");
                    ErrorHelp error = new ErrorHelp()
                    {
                         Message = message,
                         Solutions = solutions
                    };

                    return View("_ErrorView", error);
               }
          }

          //search
          public ActionResult SearchProduct(string q, int? pageRequested)
          {
               ViewBag.SearchProduct = q;
               var brands = ProductBrand.All(b => b.Name.Contains(q));
               var products = Product.All();

               //joins brands to products
               var QueryProducts = from brand in brands
                                   join pp in products
                                   on brand.Id equals pp.BrandId
                                   orderby brand.Name
                                   select pp;

               //pagination
               pageRequested = pageRequested ?? 1;
               Pagination<Product> pagination = new Pagination<Product>(QueryProducts, (int)pageRequested);
               ViewBag.TotalPages = pagination.TotalPages;
               //pagination end

               IEnumerable<ProductDisplayViewModel> model = pagination.GetPaginatedResult().Select(p => new ProductDisplayViewModel(p));
               return View("display", model);
          }

         //child actions
          [ChildActionOnly]
          public PartialViewResult GetRecentProductEntries()
          {
               List<Product> products = Product.All().OrderByDescending(i => i.Id).Take(4).ToList();
               List<ProductRecentEntriesViewModel> model = new List<ProductRecentEntriesViewModel>();
               foreach (var item in products)
               {
                    Category category = Category.GetById(item.CategoryId);
                    ProductBrand brand = ProductBrand.GetById(item.BrandId);
                    model.Add(new ProductRecentEntriesViewModel(category.Name, brand.Name, item.Description));
               }
               return PartialView("_RecentProductEntries", model);
          }

     }
}