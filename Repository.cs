using Microsoft.Extensions.Caching.Memory;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IGI_5.Models
{
    public class Repository
    {
        ApplicationContext context;

        public Repository(ApplicationContext context)
        {
            this.context = context;
        }

        public IEnumerable<Client> GetClients()
        {
            return context.Clients;
        }
        public IEnumerable<Furniture> GetFurnitures()
        {
            return context.Furnitures;
        }
        public IEnumerable<Order> GetOrders()
        {
            return context.Orders.Include("Client").Include("Furniture").Include("Worker");
        }
        public IEnumerable<Worker> GetWorkers()
        {
            return context.Workers;
        }

        public Client GetClientByName(string name)
        {
            return context.Clients.FirstOrDefault(x => x.Name == name);
        }
        public Furniture GetFurnitureByName(string name)
        {
            return context.Furnitures.FirstOrDefault(x => x.Name == name);
        }
        public Worker GetWorkerByName(string name)
        {
            return context.Workers.FirstOrDefault(x => x.Name == name);
        }

        public void AddClient(Client client)
        {
            context.Clients.Add(client);
            context.SaveChanges();
        }
        public void AddFurniture(Furniture furniture)
        {
            context.Furnitures.Add(furniture);
            context.SaveChanges();
        }
        public void AddOrder(Order order)
        {
            context.Orders.Add(order);
            context.SaveChanges();
        }
        public void AddWorker(Worker worker)
        {
            context.Workers.Add(worker);
            context.SaveChanges();
        }

        public void EditClient(Client client)
        {
            context.Entry(client).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void EditFurniture(Furniture furniture)
        {
            context.Entry(furniture).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void EditOrder(Order order)
        {
            context.Entry(order).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void EditWorker(Worker worker)
        {
            context.Entry(worker).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void RemoveClient(int id)
        {
            context.Clients.Remove(context.Clients.Find(id));
            context.SaveChanges();
        }
        public void RemoveFurniture(int id)
        {
            context.Furnitures.Remove(context.Furnitures.Find(id));
            context.SaveChanges();
        }
        public void RemoveOrder(int id)
        {
            context.Orders.Remove(context.Orders.Find(id));
            context.SaveChanges();
        }
        public void RemoveWorker(int id)
        {
            context.Workers.Remove(context.Workers.Find(id));
            context.SaveChanges();
        }
    }
}
