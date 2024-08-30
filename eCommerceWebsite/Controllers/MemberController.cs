using eCommerceWebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceWebsite.Controllers
{
    public class MemberController : Controller
    {
        private readonly CannedFoodContext _context;

        public MemberController(CannedFoodContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel r)
        {
            if(ModelState.IsValid)
            {
                // Add ??? to database
                Member newM = new()
                {
                    Email = r.Email,
                    Password = r.Password
                };

                _context.members.Add(newM);
                await _context.SaveChangesAsync();

                // Redirect to home page
                return RedirectToAction("Index", "Home");
            }
            return View(r);
        }
    }
}
