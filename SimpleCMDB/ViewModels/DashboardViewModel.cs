using SimpleCMDB.Models;
using System.Collections.Generic;

namespace SimpleCMDB.ViewModels
{
    public class DashboardViewModel
    {
        public int ServerCount { get; set; }
        public int ApplicationCount { get; set; }
        public int ServiceCount { get; set; }
        public int DependencyCount { get; set; }
        public int ActiveServers { get; set; }
        public int RunningServices { get; set; }
        public List<Server> RecentServers { get; set; } = new List<Server>();
        public List<Application> CriticalApplications { get; set; } = new List<Application>();
    }
}