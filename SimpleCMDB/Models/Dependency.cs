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

        [Display(Name = "Protocol")]
        public string? Protocol { get; set; } = "TCP"; // TCP, UDP, HTTP, HTTPS, gRPC, etc.

        [Display(Name = "Port")]
        public int? Port { get; set; }

        [Display(Name = "Service Account")]
        public string? ServiceAccount { get; set; } // Account used for authentication

        [Display(Name = "Authentication Type")]
        public string? AuthType { get; set; } // None, Basic, OAuth, Certificate, API Key, etc.

        [Display(Name = "Certificate")]
        public string? Certificate { get; set; } // Certificate name/path if using cert auth

        [Display(Name = "API Version")]
        public string? ApiVersion { get; set; } // API version if applicable

        [Display(Name = "Timeout (seconds)")]
        public int? TimeoutSeconds { get; set; } = 30;

        [Display(Name = "Retry Count")]
        public int? RetryCount { get; set; } = 3;

        [Display(Name = "Is Critical")]
        public bool IsCritical { get; set; } = false; // If true, source service fails if dependency fails

        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public virtual Service? SourceService { get; set; }
        public virtual Service? TargetService { get; set; }
    }
}