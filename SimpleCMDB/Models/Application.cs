using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleCMDB.Models
{
    public class Application
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Application Name")]
        public string Name { get; set; }

        public string? Version { get; set; }

        public string? Type { get; set; }

        public string? Language { get; set; }

        public string Criticality { get; set; } = "medium";

        public string? Owner { get; set; }

        public string? Notes { get; set; }

        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Display(Name = "Updated At")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public virtual ICollection<Service> Services { get; set; } = new List<Service>();
    }
}