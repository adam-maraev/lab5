using IGI_5.Models;
using IGI_5.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace IGI_5.Controllers
{
    public class HomeController : Controller
    {
        Repository repository;
        int pageSize = 3;

        public HomeController(ApplicationContext context)
        {
            repository = new Repository(context);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Client(int page = 1, string sort = null)
        {
            var model = repository.GetClients();
            var count = model.Count();
            if (sort != null) HttpContext.Session.SetString("ClientSort", sort);
            else sort = HttpContext.Session.GetString("ClientSort");
            switch (sort)
            {
                case "ID": model = model.OrderBy(x => x.ID); break;
                case "Name": model = model.OrderBy(x => x.Name); break;
                case "FirmName": model = model.OrderBy(x => x.FirmName); break;
                case "Phone": model = model.OrderBy(x => x.Phone); break;
                case "Adress": model = model.OrderBy(x => x.Adress); break;
            }
            model = model.Skip(pageSize * (page - 1)).Take(pageSize);
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            ViewBag.PageViewModel = pageViewModel;
            return View(model);
        }
        public IActionResult Furniture(int page = 1, string sort = null, int filter = 0)
        {
            var model = repository.GetFurnitures();
            if (filter > 0) HttpContext.Session.SetInt32("FurnitureFilter", filter);
            else filter = HttpContext.Session.GetInt32("FurnitureFilter") ?? 0;
            model = model.Where(x => x.Cost > filter);
            var count = model.Count();
            if (sort != null) HttpContext.Session.SetString("FurnitureSort", sort);
            else sort = HttpContext.Session.GetString("FurnitureSort");
            switch (sort)
            {
                case "ID": model = model.OrderBy(x => x.ID); break;
                case "Name": model = model.OrderBy(x => x.Name); break;
                case "Material": model = model.OrderBy(x => x.Material); break;
                case "Description": model = model.OrderBy(x => x.Description); break;
                case "Cost": model = model.OrderBy(x => x.Cost); break;
                case "Count": model = model.OrderBy(x => x.Count); break;
            }
            model = model.Skip(pageSize * (page - 1)).Take(pageSize);
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            ViewBag.PageViewModel = pageViewModel;
            return View(model);
        }
        public IActionResult Order(int page = 1, string sort = null)
        {
            var model = repository.GetOrders();
            var count = model.Count();

            if (sort != null) HttpContext.Session.SetString("OrderSort", sort);
            else sort = HttpContext.Session.GetString("OrderSort");

            switch (sort)
            {
                case "ID": model = model.OrderBy(x => x.ID); break;
                case "OrderDate": model = model.OrderBy(x => x.OrderDate); break;
                case "IsOrderComplete": model = model.OrderBy(x => x.IsOrderComplete); break;
                case "Discount": model = model.OrderBy(x => x.Discount); break;
                case "Client": model = model.OrderBy(x => x.Client.Name); break;
                case "Furniture": model = model.OrderBy(x => x.Furniture.Name); break;
                case "Worker": model = model.OrderBy(x => x.Worker.Name); break;
            }

            model = model.Skip(pageSize * (page - 1)).Take(pageSize);
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            ViewBag.PageViewModel = pageViewModel;


            return View(model);
        }
        public IActionResult Worker(int page = 1, string sort = null)
        {
            var model = repository.GetWorkers();
            var count = model.Count();
            if (sort != null) HttpContext.Session.SetString("WorkerSort", sort);
            else sort = HttpContext.Session.GetString("WorkerSort");
            switch (sort)
            {
                case "ID": model = model.OrderBy(x => x.ID); break;
                case "Name": model = model.OrderBy(x => x.Name); break;
            }
            model = model.Skip(pageSize * (page - 1)).Take(pageSize);
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            ViewBag.PageViewModel = pageViewModel;
            return View(model);
        }
    }
}