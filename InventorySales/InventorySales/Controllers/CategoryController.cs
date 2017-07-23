using InventorySales.Models;
using InventorySales.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventorySales.Controllers
{
     public class CategoryController : Controller
     {
          // GET: Category
          public ActionResult Index()
          {
               return RedirectToAction("display");
          }

          public ActionResult SubMenu()
          {
               return View();
          }

          public ActionResult Display()
          {
               var categories = Category.All();
               return View(categories);
          }

          [HttpGet]
          public ActionResult Add()
          {
               CategoryAddEditViewModel model = new CategoryAddEditViewModel();
               return View(model);
          }

          [Authorize, HttpPost]
          public ActionResult Add(CategoryAddEditViewModel categoryFormData)
          {
               Category category = new Category(categoryFormData.Name);
               if (!category.Exists)
               {
                    category.Save();
                    return RedirectToAction("add");
               }
               else
               {
                    string message = "An Error occured when trying to add new category.";
                    List<string> solutions = new List<string>();
                    solutions.Add("Category Already exists");
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
               Category category = Category.GetById(id);
               CategoryAddEditViewModel model = new CategoryAddEditViewModel(category.Id, category.Name);
               return View(model);
          }

          [Authorize, HttpPost]
          public ActionResult Edit(CategoryAddEditViewModel formData)
          {
               Category category = new Category()
               {
                    Id = formData.Id,
                    Name = formData.Name
               };
               if (!category.Exists)
               {
                    category.Update();
                    return RedirectToAction("display");
               }
               else
               {
                    string message = "An Error occured when trying to edit category.";
                    List<string> solutions = new List<string>();
                    solutions.Add("Category Already exists");
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
                    Category category = Category.GetById(id);
                    category.Remove();
                    return RedirectToAction("display");
               }
               catch
               {
                    string message = "An Error occured when trying to delete category.";
                    List<string> solutions = new List<string>();
                    solutions.Add("Ensure that the category you're trying to delete is not a part of your product list");
                    ErrorHelp error = new ErrorHelp()
                    {
                         Message = message,
                         Solutions = solutions
                    };

                    return View("_ErrorView", error);
               }
          }

          //child actions

          [ChildActionOnly]
          public PartialViewResult GetRecentCategoryEntries()
          {
               List<Category> model = Category.All().OrderByDescending(i => i.Id).Take(4).ToList();
              
               return PartialView("_RecentCategoryEntries", model);
          }
     }
}
