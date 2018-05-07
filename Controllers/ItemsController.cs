using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class ItemsController : Controller
    {
        [HttpGet("/items")]
        public ActionResult Items()
        {
            List<Item> allItems = Item.GetAll();
            return View(allItems);
        }

        [HttpGet("/items/new")]
        public ActionResult CreateForm()
        {
            return View();
        }

        [HttpPost("/items")]
        public ActionResult Create()
        {
          Item newItem = new Item (Request.Form["new-item"],int.Parse(Request.Form["new-category"]));
          newItem.Save();
          List<Item> allItems = Item.GetAll();
          return View("Items", allItems);
        }
        [HttpGet("/")]
        public ActionResult Index()
        {
            List<Item> allItems = Item.GetAll();
            return View(allItems);
        }
        [HttpPost("/category")]
        public ActionResult Indexc()
        {
            Category newItem = new Category (Request.Form["new-category"]);
            newItem.Save();
            List<Category> allItems = Category.GetAll();
            return View(allItems);
        }
        [HttpGet("/category/new")]
        public ActionResult Createcategory()
        {
            return View();
        }

    }
}
