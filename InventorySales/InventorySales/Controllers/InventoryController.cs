using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InventorySales.ViewModels;
using InventorySales.Models;
using InventorySales.Common;

namespace InventorySales.Controllers
{
     public class InventoryController : Controller
     {
          // GET: Inventory
          public ActionResult Index()
          {
              return RedirectToAction("Display");
          }

          public ActionResult SubMenu()
          {
               return View();
          }

          public ActionResult Display(int? pageRequested)
          {
               IEnumerable<Inventory> QueryInventory = Inventory.All();

               //pagination
               pageRequested = pageRequested ?? 1;
               Pagination<Inventory> pagination = new Pagination<Inventory>(QueryInventory, (int)pageRequested);
               ViewBag.TotalPages = pagination.TotalPages;
               //pagination end

               //sets model
               IEnumerable<InventoryDisplayViewModel> model = pagination.GetPaginatedResult().Select(p => new InventoryDisplayViewModel(p));
               return View(model);
          }
    
          public ActionResult SearchProduct(string q)
          {
               ViewBag.SearchProduct = q;

               var brands = ProductBrand.All(b => b.Name.Contains(q));
               var products = Product.All();
               var inventories = Inventory.All();

               //joins brands to products
               var QueryProducts = from brand in brands
                                   join pp in products
                                   on brand.Id equals pp.BrandId
                                   select pp;

               //joins inventory to products
               var QueryInventory = from prod in QueryProducts
                                    join inven in inventories
                                    on prod.Id equals inven.ProductId
                                    select inven;

               //pagination
               Pagination<Inventory> pagination = new Pagination<Inventory>(QueryInventory, 1);
               ViewBag.TotalPages = pagination.TotalPages;
               //pagination end

               //sets model
               IEnumerable<InventoryDisplayViewModel> model = pagination.GetPaginatedResult().Select(p => new InventoryDisplayViewModel(p));
               return View("display", model);
          }

          [HttpGet]
          public ActionResult Add()
          {
               ViewBag.Brands = DataLists.ProductBrandsWithDescription();
               ViewBag.Descriptions = DataLists.ProductDescription(0);

               return View(new InventoryAddViewModel());
          }

          [Authorize, HttpPost]
          public ActionResult Add(InventoryAddViewModel formData)
          {
               Product product = Product.All(p => p.BrandId == formData.BrandId && p.Description == formData.Description).Single();
               Inventory inventory = new Inventory()
               {
                    ProductId = product.Id,
                    PricePaidPerUnit = formData.PricePaidPerUnit,
                    UnitsPurchased = formData.UnitsPurchased,
                    UnitsSold = formData.UnitsSold
               };
               if (!inventory.Exists)
               {
                    inventory.Save();
                    return RedirectToAction("Add");
               }
               else
               {
                    string message = "An Error occured when trying to add new inventory.";
                    List<string> solutions = new List<string>();
                    solutions.Add("Inventory Already exists");
                    ErrorHelp error = new ErrorHelp()
                    {
                         Message = message,
                         Solutions = solutions
                    };

                    return View("_ErrorView", error);
               }
          }

          [Authorize, HttpGet]
          public ActionResult Edit(int id)
          {
               Inventory inventory = Inventory.GetById(id);
               Product product = Product.GetById(inventory.ProductId);
               ViewBag.Categories = DataLists.Categories();
               ViewBag.Brands = DataLists.ProductBrandsWithDescription();
               ViewBag.Descriptions = DataLists.ProductDescription(product.BrandId);

               InventoryEditViewModel model = new InventoryEditViewModel()
               {
                    Id = inventory.Id,
                    BrandId = product.BrandId,
                    Description = product.Description,
                    PricePaidPerUnit = inventory.PricePaidPerUnit,
                    UnitsPurchased = inventory.UnitsPurchased,
                    UnitsSold = inventory.UnitsSold,
                    CategoryId = product.CategoryId

               };
               return View(model);
          }

          [Authorize, HttpPost]
          public ActionResult Edit(InventoryEditViewModel formData)
          {

               Product product = Product.All(p => p.BrandId == formData.BrandId && p.Description == formData.Description).Single();
               Inventory inventory = new Inventory()
               {
                    Id = formData.Id,
                    ProductId = product.Id,
                    PricePaidPerUnit = formData.PricePaidPerUnit,
                    UnitsPurchased = formData.UnitsPurchased,
                    UnitsSold = formData.UnitsSold
               };
               inventory.Update();
               return RedirectToAction("Display");
          }

          [Authorize]
          public ActionResult Delete(int id)
          {
               Inventory inventory = Inventory.GetById(id);
               inventory.Remove();
               //returns list of all products
               return RedirectToAction("Display");
          }


          [ChildActionOnly]
          public PartialViewResult GetRecentInventoryEntries()
          {
               List<Inventory> inventory = Inventory.All().OrderByDescending(i => i.Id).Take(4).ToList();
               List<InventoryRecentEntriesViewModel> model = new List<InventoryRecentEntriesViewModel>();
               foreach (var item in inventory)
               {
                    Product p = Product.GetById(item.ProductId);
                    ProductBrand pb = ProductBrand.GetById(p.BrandId);
                    model.Add(new InventoryRecentEntriesViewModel(pb.Name, p.Description, item.UnitsPurchased, item.UnitsSold, item.PricePaidPerUnit));
               }
               return PartialView("_RecentInventoryEntries", model);
          }

          [ChildActionOnly]
          public PartialViewResult GetInventoryRunningLow()
          {
               List<Inventory> inventory = Inventory.All(i => (i.UnitsPurchased - i.UnitsSold) < Common.commonValues.MinimumInventoryUnitsBeforeNotification).ToList();
               List<InventoryRunningLowViewModel> model = new List<InventoryRunningLowViewModel>();
               foreach (var item in inventory)
               {
                    int unitsLeft = item.UnitsPurchased - item.UnitsSold;
                    Product p = Product.GetById(item.ProductId);
                    ProductBrand pb = ProductBrand.GetById(p.BrandId);
                    model.Add(new InventoryRunningLowViewModel(p.Id, pb.Name, p.Description, unitsLeft));
               }
               return PartialView("_RunningLow", model);
          }
     }
}