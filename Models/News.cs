using System.ComponentModel.DataAnnotations;

namespace KhmerFestivalWebsite.Models
{
    public class News
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        
        [Required]
        public string Title { get; set; } = string.Empty;
        
        [Required]
        public string Content { get; set; } = string.Empty;
        
        public string Excerpt { get; set; } = string.Empty;
        
        public string ImageUrl { get; set; } = string.Empty;
        
        public DateTime PublishedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}