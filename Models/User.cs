using System.ComponentModel.DataAnnotations;

namespace KhmerFestivalWebsite.Models
{
    public class User
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        
        [Required]
        public string Role { get; set; } = "user";
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}