using SimpleCMDB.Models;
using System.Collections.Generic;

namespace SimpleCMDB.ViewModels
{
    public class DependencyViewModel
    {
        public IEnumerable<Dependency> Dependencies { get; set; } = new List<Dependency>();
        public IEnumerable<Service> Services { get; set; } = new List<Service>();
    }
}