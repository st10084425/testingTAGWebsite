using System.ComponentModel.DataAnnotations;

namespace TAG_website.Models
{
    public class FAQModel
    {  
        
    public int Id { get; set; }

    [Required]
    [EmailAddress]
     public string UserEmail { get; set; }

    [Required]
    public string Questions { get; set; }
    public DateTime SubmissionTime { get; set; }

    }
}
