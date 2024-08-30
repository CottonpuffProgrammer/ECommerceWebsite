using eCommerceWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace eCommerceWebsite.Controllers
{
    public class MemberController : Controller
    {
        // Used to interact with Database
        private readonly CannedFoodContext _context;

        public MemberController(CannedFoodContext context)
        {
            _context = context;
        }

        // Register functionality
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

        // Login functionality
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel l)
        {
            if (ModelState.IsValid)
            {
                // Check Database for credentials
                Member? m = (from member in _context.members
                             where member.Email == l.Email &&
                                   member.Password == l.Password
                                   select member).SingleOrDefault();

                // If exists, send to homepage
                if (m != null)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Credentials not found!");

                // If no record matches, display error
                return View(l);
            }
            // Return if no record found or ModelState is invalid
            return View(l);
        }
    }
}
