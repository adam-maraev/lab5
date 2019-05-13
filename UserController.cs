using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IGI_5.Models;
using IGI_5.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace IGI_5.Controllers
{
    [Authorize(Roles = "admin, user")]
    public class UserController : Controller
    {
        Repository repository;
                     
        public UserController(ApplicationContext context)
        {
            repository = new Repository(context);
        }
        
        [HttpGet]
        public ActionResult AddClient()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddFurniture()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddOrder()
        {
            ViewBag.Clients = repository.GetClients();
            ViewBag.Furnitures = repository.GetFurnitures();
            ViewBag.Workers = repository.GetWorkers();
            return View();
        }
        [HttpGet]
        public ActionResult AddWorker()
        {
            return View();
        }


        [HttpGet]
        public ActionResult EditClient(int id)
        {
            var model = repository.GetClients().FirstOrDefault(x => x.ID == id);
            return View(model);
        }
        [HttpGet]
        public ActionResult EditFurniture(int id)
        {
            var model = repository.GetFurnitures().FirstOrDefault(x => x.ID == id);
            return View(model);
        }
        [HttpGet]
        public ActionResult EditOrder(int id)
        {
            var model = repository.GetOrders().FirstOrDefault(x => x.ID == id);
            ViewBag.Clients = repository.GetClients();
            ViewBag.Furnitures = repository.GetFurnitures();
            return View(model);
        }
        [HttpGet]
        public ActionResult EditWorker(int id)
        {
            var model = repository.GetWorkers().FirstOrDefault(x => x.ID == id);
            return View(model);
        }


        [HttpGet]
        public ActionResult RemoveClient(int id)
        {
            var model = repository.GetClients().FirstOrDefault(x => x.ID == id);
            return View(model);
        }
        [HttpGet]
        public ActionResult RemoveFurniture(int id)
        {
            var model = repository.GetFurnitures().FirstOrDefault(x => x.ID == id);
            return View(model);
        }
        [HttpGet]
        public ActionResult RemoveOrder(int id)
        {
            var model = repository.GetOrders().FirstOrDefault(x => x.ID == id);
            return View(model);
        }
        [HttpGet]
        public ActionResult RemoveWorker(int id)
        {
            var model = repository.GetWorkers().FirstOrDefault(x => x.ID == id);
            return View(model);
        }



        [HttpPost]
        public ActionResult AddClient(Client client)
        {
            if (ModelState.IsValid)
            {
                repository.AddClient(client);
                return RedirectToAction("Client", "Home");
            }
            return View(client);
        }
        [HttpPost]
        public ActionResult AddFurniture(Furniture furniture)
        {
            if (ModelState.IsValid)
            {
                repository.AddFurniture(furniture);
                return RedirectToAction("Furniture", "Home");
            }
            return View(furniture);
        }
        [HttpPost]
        public ActionResult AddOrder(Order order, string clientName, string furnitureName, string workerName)
        {
            if (ModelState.IsValid)
            {
                order.Client = repository.GetClientByName(clientName);
                order.Furniture = repository.GetFurnitureByName(furnitureName);
                order.Worker = repository.GetWorkerByName(workerName);
                repository.AddOrder(order);
                return RedirectToAction("Order", "Home");
            }
            ViewBag.Clients = repository.GetClients();
            ViewBag.Furnitures = repository.GetFurnitures();
            ViewBag.Workers = repository.GetWorkers();
            return View(order);
        }
        [HttpPost]
        public ActionResult AddWorker(Worker worker)
        {
            if (ModelState.IsValid)
            {
                repository.AddWorker(worker);
                return RedirectToAction("Worker", "Home");
            }
            return View(worker);
        }


        [HttpPost]
        public ActionResult EditClient(Client client)
        {
            if (ModelState.IsValid)
            {
                repository.EditClient(client);
                return RedirectToAction("Client", "Home");
            }
            return View(client);
        }
        [HttpPost]
        public ActionResult EditFurniture(Furniture furniture)
        {
            if (ModelState.IsValid)
            {
                repository.EditFurniture(furniture);
                return RedirectToAction("Furniture", "Home");
            }
            return View(furniture);
        }
        [HttpPost]
        public ActionResult EditOrder(Order order, string furnitureName, string clientName)
        {
            if (ModelState.IsValid)
            {
                order.Furniture = repository.GetFurnitureByName(furnitureName);
                order.Client = repository.GetClientByName(clientName);
                repository.EditOrder(order);
                ViewBag.Clients = repository.GetClients();
                ViewBag.Furnitures = repository.GetFurnitures();
                return RedirectToAction("Order", "Home");
            }
            return View(order);
        }
        [HttpPost]
        public ActionResult EditWorker(Worker worker)
        {
            if (ModelState.IsValid)
            {
                repository.EditWorker(worker);
                return RedirectToAction("Worker", "Home");
            }
            return View(worker);
        }


        [HttpPost]
        public ActionResult RemoveClients(int id)
        {
            repository.RemoveClient(id);
            return RedirectToAction("Client", "Home");
        }
        [HttpPost]
        public ActionResult RemoveFurnitures(int id)
        {
            repository.RemoveFurniture(id);
            return RedirectToAction("Furniture", "Home");
        }
        [HttpPost]
        public ActionResult RemoveOrders(int id)
        {
            repository.RemoveOrder(id);
            return RedirectToAction("Course", "Home");
        }
        [HttpPost]
        public ActionResult RemoveWorkers(int id)
        {
            repository.RemoveWorker(id);
            return RedirectToAction("Worker", "Home");
        }
    }
}