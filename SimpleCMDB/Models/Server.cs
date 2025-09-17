using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleCMDB.Models
{
    public class Server
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Hostname")]
        public string Hostname { get; set; }

        [Display(Name = "IP Address")]
        public string? IpAddress { get; set; }

        [Display(Name = "OS Type")]
        public string? OsType { get; set; }

        [Display(Name = "OS Version")]
        public string? OsVersion { get; set; }

        public string Environment { get; set; } = "production";

        public string Status { get; set; } = "active";

        public string? Owner { get; set; }

        public string? Location { get; set; }

        public string? Notes { get; set; }

        [Display(Name = "CPU Count")]
        public int? CpuCount { get; set; }

        [Display(Name = "Memory (GB)")]
        public decimal? MemoryGb { get; set; }

        [Display(Name = "Disk (GB)")]
        public decimal? DiskGb { get; set; }

        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Display(Name = "Updated At")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public virtual ICollection<Service> Services { get; set; } = new List<Service>();
    }
}