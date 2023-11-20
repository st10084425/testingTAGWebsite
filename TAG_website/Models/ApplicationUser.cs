
using Microsoft.AspNetCore.Identity;


namespace TAG_website.Models
{
    public class ApplicationUser : IdentityUser
    {

        public string firstName { get; set; }
        public string lastName { get; set; }
        public string contactNumber { get; set; }


        public ApplicationUser()
        {
            // You can set default values or initialize properties in the constructor if needed.
            firstName = string.Empty;
            lastName = string.Empty;
            contactNumber = string.Empty;   
        }
    }




}

