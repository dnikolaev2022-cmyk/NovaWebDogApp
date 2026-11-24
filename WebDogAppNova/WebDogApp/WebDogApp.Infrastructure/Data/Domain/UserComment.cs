using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDogApp.Infrastructure.Data.Domain
{
    public class UserComment
    {
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        public string Comment { get; set; } = null!;
    }
}
