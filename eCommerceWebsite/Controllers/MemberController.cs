using Microsoft.AspNetCore.Mvc;

namespace eCommerceWebsite.Controllers
{
    public class MemberController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
    }
}
