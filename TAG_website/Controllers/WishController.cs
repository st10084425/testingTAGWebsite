using Microsoft.AspNetCore.Mvc;

namespace TAG_website.Controllers
{
    public class WishController : Controller
    {
        public IActionResult Wish()
        {
            return View();
        }
    }
}
