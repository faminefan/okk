using Microsoft.AspNetCore.Mvc;
using okk.Models;

namespace okk
{
    public class OrdersController : Controller
    {
        static List<Order> orders = new()
        {
            new Order { Id = 1, Name = "Electroniucs" },
            new Order { Id = 2, Name = "Sport" },
            new Order { Id = 3, Name = "Food & Drinks" },
        };

        public IActionResult Index()
        {
            return View(orders);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            var item = orders.FirstOrDefault(x => x.Id == id);

            if (item == null)
                return NotFound(); // 404

            return View(item);
        }

        [HttpPost]
        public IActionResult SaveNew(Order element)
        {
            orders.Add(element);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(Order element)
        {
            var index = orders.FindIndex(x => x.Id == element.Id);
            orders[index] = element;

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            // delete logic
            var item = orders.Find(x => x.Id == id);

            if (item == null)
                return NotFound(); // 404

            orders.Remove(item);

            return RedirectToAction("Index");
        }
    }
}