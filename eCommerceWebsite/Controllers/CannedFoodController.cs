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

        public async Task<IActionResult> Index(int? id)
        {
            const int FoodToDisplay = 3;
            const int PageOffset = 1; // Need page offset to use figure out correct page
            
            int currPage = id ?? 1; // Set currPage to id if it has a value, otherwise use 1
            



            // Get all food from the Database
            List<CannedFood> food = await _context.cannedFoods
                                           .Skip(FoodToDisplay * (currPage - PageOffset))
                                           .Take(FoodToDisplay)
                                           .ToListAsync();

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

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            CannedFood? foodToEdit = await _context.cannedFoods.FindAsync(id);

            if (foodToEdit == null)
            {
                return NotFound();
            }

            return View(foodToEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CannedFood foodModel)
        {
            if (ModelState.IsValid)
            {
                _context.cannedFoods.Update(foodModel);
                await _context.SaveChangesAsync();

                TempData["Message"] = $"{foodModel.FoodName} was updated successfully!";
                return RedirectToAction("Index");
            }

            return View(foodModel);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            CannedFood? foodToDelete = await _context.cannedFoods.FindAsync(id);

            if (foodToDelete == null)
            {
                return NotFound();
            }

            return View(foodToDelete);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmedAsync(int id)
        {
            CannedFood? foodToDelete = await _context.cannedFoods.FindAsync(id);
            
            if (foodToDelete != null)
            {
                _context.cannedFoods.Remove(foodToDelete);
                await _context.SaveChangesAsync();
                TempData["Message"] = foodToDelete.FoodName + " was deleted successfully!";
                return RedirectToAction("Index");
            }

            TempData["Message"] = "This was already deleted!";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            CannedFood? foodDetails = await _context.cannedFoods.FindAsync(id);

            if (foodDetails == null)
            {
                return NotFound();
            }

            return View(foodDetails);
        }
    }
}
