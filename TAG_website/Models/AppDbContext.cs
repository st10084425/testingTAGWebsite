using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TAG_website.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {


        //ctor (tab tab)
        public AppDbContext(DbContextOptions<AppDbContext> options) :

            //parse options to the db
            base(options)
        {
        }
        // data sets generated to save to database

        public DbSet<FAQModel> FAQModel { get; set; }
        public DbSet<Donate> Donate { get; set; }
    }
}
