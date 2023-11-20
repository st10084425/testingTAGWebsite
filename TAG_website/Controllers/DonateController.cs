using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using TAG_website.Models;

namespace TAG_website.Controllers
{

    [Authorize]
    public class DonateController : Controller
    {



        private readonly AppDbContext _dbContext; 

        public DonateController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Donate()
        {
            return View();
        }




        [HttpPost]
        public IActionResult SubmitDonation(Donate donation)
        {
            if (ModelState.IsValid)
            {
                // Save other data to the database
                _dbContext.Donate.Add(donation);
                _dbContext.SaveChanges();

                // Redirect to the DropZone page
                return RedirectToAction("DropZone", "DropZone");
            }

            return View("donate", donation); // Return to the form with validation errors
        }





    }
}
