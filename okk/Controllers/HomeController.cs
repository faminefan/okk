using Microsoft.AspNetCore.Mvc;
using okk.Models;
using System.Diagnostics;

namespace okk.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        static List<Ñlothing> clothes = new List<Ñlothing>

            { new Ñlothing { Id = 1, Title = "T-Shirt", Material = "Cotton", Price = 499, Size = "M", Brand = "Nike" },
            new Ñlothing { Id = 2, Title = "Jeans", Material = "Denim", Price = 1299, Size = "L", Brand = "Levi's" },
            new Ñlothing { Id = 3, Title = "Jacket", Material = "Leather", Price = 2999, Size = "XL", Brand = "Zara" },
            new Ñlothing { Id = 4, Title = "Sweater", Material = "Wool", Price = 899, Size = "M", Brand = "H&M" },
            new Ñlothing { Id = 5, Title = "Shorts", Material = "Cotton", Price = 599, Size = "L", Brand = "Adidas" },
            new Ñlothing { Id = 6, Title = "Dress", Material = "Silk", Price = 1599, Size = "S", Brand = "Gucci" },
            new Ñlothing { Id = 7, Title = "Skirt", Material = "Polyester", Price = 799, Size = "M", Brand = "Mango" },
            new Ñlothing { Id = 8, Title = "Coat", Material = "Wool", Price = 2499, Size = "L", Brand = "Burberry" },
            new Ñlothing { Id = 9, Title = "Hoodie", Material = "Cotton", Price = 899, Size = "XL", Brand = "Puma" },
            new Ñlothing { Id = 10, Title = "Blazer", Material = "Linen", Price = 1999, Size = "M", Brand = "Armani" }
        };
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AdminPanel()
        {
            return View(clothes);
        }

        public IActionResult Products()
        {
            return View();
        }
        public IActionResult Delete(int id)
        {
            // delete logic
            var item = clothes.Find(x => x.Id == id);
            if (item == null)
                return NotFound();
            clothes.Remove(item);


            return RedirectToAction("AdminPanel");
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveProduct(Ñlothing element)
        {
            clothes.Add(element);
            return RedirectToAction("AdminPanel");
        }
        public IActionResult Details()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}