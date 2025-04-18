using System.ComponentModel.DataAnnotations;

namespace Basma_App.Models
{

    public class AppUser
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; } // Plain text (NOT recommended for production)
    }

}
