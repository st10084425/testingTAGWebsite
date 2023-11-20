using Microsoft.AspNetCore.Mvc;

namespace TAG_website.Controllers
{
    public class DropZoneController : Controller
    {
        public IActionResult DropZone()
        {
            return View();
        }
    }
}
