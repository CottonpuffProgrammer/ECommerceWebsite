using eCommerceWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Text;

namespace eCommerceWebsite.Controllers
{
    public class CannedFoodController : Controller
    {
        private readonly CannedFoodContext _context;

        public CannedFoodController(CannedFoodContext context)
        {
            _context = context;
        }

        /// <summary>
        /// The create page, "[HttpGet]" displays
        /// this page first
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CannedFood food)
        {
            if (ModelState.IsValid)
            {
                // Add to database
                _context.cannedFoods.Add(food); // Prepares insert
                _context.SaveChanges(); // Executes pending insert

                // Show success message on page
                ViewData["Message"] = $"{food.FoodName} was added successfully!";
                return View();
            }

            return View(food);
        }
    }
}
