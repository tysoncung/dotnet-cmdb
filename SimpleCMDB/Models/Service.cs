using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleCMDB.Models
{
    public class Service
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Service Name")]
        public string ServiceName { get; set; }

        [Display(Name = "Server")]
        public int? ServerId { get; set; }

        [Display(Name = "Application")]
        public int? ApplicationId { get; set; }

        public int? Port { get; set; }

        public string? Protocol { get; set; } = "tcp";

        public string Status { get; set; } = "running";

        [Display(Name = "Process Name")]
        public string? ProcessName { get; set; }

        [Display(Name = "Start Command")]
        public string? StartCommand { get; set; }

        [Display(Name = "Config File")]
        public string? ConfigFile { get; set; }

        [Display(Name = "Log File")]
        public string? LogFile { get; set; }

        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Display(Name = "Updated At")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public virtual Server? Server { get; set; }
        public virtual Application? Application { get; set; }
        public virtual ICollection<Dependency> SourceDependencies { get; set; } = new List<Dependency>();
        public virtual ICollection<Dependency> TargetDependencies { get; set; } = new List<Dependency>();
    }
}