using Microsoft.AspNetCore.Mvc;

namespace TAG_website.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Payment()
        {
            return View();
        }
    }
}
