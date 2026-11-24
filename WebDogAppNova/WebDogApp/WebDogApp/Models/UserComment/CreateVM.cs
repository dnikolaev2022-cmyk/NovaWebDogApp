using System.ComponentModel.DataAnnotations;

namespace WebDogApp.Models.UserComment
{
    public class CreateVM
    {
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        public string Comment { get; set; } = null!;
    }
}
