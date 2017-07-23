using InventorySales.Models;
using InventorySales.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventorySales.Controllers
{
     public class ProductBrandController : Controller
     {
          // GET: ProductBrand
          public ActionResult Index()
          {
               return RedirectToAction("display");
          }

          public ActionResult SubMenu()
          {
               return View();
          }

          [Authorize, HttpGet]
          public ActionResult Edit(int id)
          {
               ProductBrand brand = ProductBrand.GetById(id);
               ProductBrandAddEditViewModel model = new ProductBrandAddEditViewModel() { Id = brand.Id, Name = brand.Name };
               return View(model);
          }

          [Authorize, HttpPost]
          public ActionResult Edit(ProductBrandAddEditViewModel formData)
          {
               ProductBrand brand = new ProductBrand()
               {
                    Id = formData.Id,
                    Name = formData.Name
               };
               brand.Update();
               return RedirectToAction("Display");
          }

          [HttpGet]
          public ActionResult Add()
          {
               return View();
          }

          [Authorize, HttpPost]
          public ActionResult Add(ProductBrandAddEditViewModel formData)
          {
               ProductBrand brand = new ProductBrand()
               {
                    Name = formData.Name,
               };
               if (!brand.Exists())
               {
                    brand.Add();
                    return RedirectToAction("Add");
               }
               else
               {
                    string message = "An Error occured when trying to add new brand.";
                    List<string> solutions = new List<string>();
                    solutions.Add("Brand Already exists");
                    ErrorHelp error = new ErrorHelp()
                    {
                         Message = message,
                         Solutions = solutions
                    };

                    return View("_ErrorView", error);
               }
          }

          [Authorize]
          public ActionResult Delete(int id)
          {
               try
               {
                    ProductBrand brand = ProductBrand.GetById(id);
                    brand.Remove();
                    return RedirectToAction("Display");
               }
               catch
               {
                    string message = "An Error occured when trying to delete brand.";
                    List<string> solutions = new List<string>();
                    solutions.Add("Ensure that the brand you're trying to delete is not a part of your product list");
                    ErrorHelp error = new ErrorHelp()
                    {
                         Message = message,
                         Solutions = solutions
                    };

                    return View("_ErrorView", error);
               }
          }

          public ActionResult Display()
          {
               var brands = ProductBrand.All();
               return View(brands);
          }

          //child actions
          [ChildActionOnly]
          public PartialViewResult GetRecentProductBrandEntries()
          {
               List<ProductBrand> model = ProductBrand.All().OrderByDescending(i => i.Id).Take(4).ToList();

               return PartialView("_RecentProductBrandEntries", model);
          }
     }
}