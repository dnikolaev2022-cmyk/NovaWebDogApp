using System.ComponentModel.DataAnnotations;

namespace WebDogApp.Models
{
    public class ErrorViewModel
    {
        [Display(Name = "Description")]
        public string Description { get; set; } = null!;
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
