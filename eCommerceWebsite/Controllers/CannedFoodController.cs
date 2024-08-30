using eCommerceWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IActionResult> Index()
        {
            // Get all food from the Database
            List<CannedFood> food = await _context.cannedFoods.ToListAsync();

            // Show them on the page
            return View(food);
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

        /// <summary>
        /// Async method to create and add a new
        /// canned food to database
        /// </summary>
        /// <param name="food">Food to be added</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CannedFood food)
        {
            if (ModelState.IsValid)
            {
                // Add to database
                _context.cannedFoods.Add(food);    // Prepares insert
                await _context.SaveChangesAsync(); // Executes pending insert

                // Show success message on page
                ViewData["Message"] = $"{food.FoodName} was added successfully!";
                return View();
            }

            return View(food);
        }
    }
}
