using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleCMDB.Data;
using SimpleCMDB.Models;
using SimpleCMDB.ViewModels;

namespace SimpleCMDB.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly CmdbContext _context;

    public HomeController(ILogger<HomeController> logger, CmdbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var viewModel = new DashboardViewModel
        {
            ServerCount = await _context.Servers.CountAsync(),
            ApplicationCount = await _context.Applications.CountAsync(),
            ServiceCount = await _context.Services.CountAsync(),
            DependencyCount = await _context.Dependencies.CountAsync(),
            ActiveServers = await _context.Servers.CountAsync(s => s.Status == "active"),
            RunningServices = await _context.Services.CountAsync(s => s.Status == "running"),
            RecentServers = await _context.Servers
                .OrderByDescending(s => s.CreatedAt)
                .Take(5)
                .ToListAsync(),
            CriticalApplications = await _context.Applications
                .Where(a => a.Criticality == "critical")
                .ToListAsync()
        };

        return View(viewModel);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
