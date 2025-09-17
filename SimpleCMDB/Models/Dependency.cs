using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleCMDB.Models
{
    public class Dependency
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Source Service")]
        public int SourceServiceId { get; set; }

        [Required]
        [Display(Name = "Target Service")]
        public int TargetServiceId { get; set; }

        public string? Description { get; set; }

        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public virtual Service? SourceService { get; set; }
        public virtual Service? TargetService { get; set; }
    }
}