using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TAG_website.Models
{
    public class Donate
    {


        public int Id { get; set; }

        public string? typeOfItem { get; set; }
        public string? otherItem { get; set; }
        public string? nameOfItem { get; set; }
        public string? shortDescription { get; set; }

        public int quantity { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfDonation { get; set; }

    }
}
