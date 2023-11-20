using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TAG_website.Models;

namespace TAG_website.Controllers
{
    public class AboutController : Controller
    {
        private readonly IEmailService _emailService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AppDbContext _dbContext; // Inject the AppDbContext here

        public AboutController(
            IEmailService emailService,
            UserManager<ApplicationUser> userManager,
            AppDbContext dbContext) // Add the AppDbContext as a parameter
        {
            _emailService = emailService;
            _userManager = userManager;
            _dbContext = dbContext; // Assign the injected AppDbContext to the local variable
        }

        [HttpPost]
        [Authorize]

        public async Task<IActionResult> SubmitFAQ(FAQModel model, string returnUrl = null)
        {
            // Get the currently logged-in user's email
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                // Redirect to login if the user is not authenticated

                return RedirectToAction("/Account/Login");
            }

            // Use the user's email for the FAQ questions
            model.UserEmail = user.Email;




            // Save the FAQ questions to the database
            var faqModel = new FAQModel
            {
                UserEmail = model.UserEmail,
                Questions = model.Questions,
                SubmissionTime = DateTime.Now
            };

            // Use your AppDbContext here to save the data to the database
            // You can inject it into the controller just like the IEmailService and UserManager
            _dbContext.FAQModel.Add(faqModel);
            await _dbContext.SaveChangesAsync();

            // Compose the email content with the FAQ questions
            var subject = "New FAQ Questions";
            var message = $"User: {model.UserEmail}\n\nQuestions:\n{model.Questions}";

            // Send the email to the specific email address
            await _emailService.SendFAQQuestionsAsync("avishmaharaj2003@gmail.com", subject, message);

            // If there is a returnUrl, redirect to it (e.g., back to SubmitFAQ after login)
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return LocalRedirect(returnUrl);
            }

            // Otherwise, redirect to the FAQSubmitted page
            return RedirectToAction("FAQSubmitted");
        }





        public IActionResult About()
        {
            return View();
        }

        public IActionResult FAQSubmitted()
        {
            return View();
        }
    }
}
