using System.ComponentModel.DataAnnotations;

namespace KhmerFestivalWebsite.Models
{
    public class Festival
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        
        [Required]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        public string Description { get; set; } = string.Empty;
        
        public string Meaning { get; set; } = string.Empty;
        
        public string Organization { get; set; } = string.Empty;
        
        public string TimePeriod { get; set; } = string.Empty;
        
        public string Location { get; set; } = string.Empty;
        
        public string ImageUrl { get; set; } = string.Empty;
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}