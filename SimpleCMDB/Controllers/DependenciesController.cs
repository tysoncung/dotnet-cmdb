using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SimpleCMDB.Data;
using SimpleCMDB.Models;
using SimpleCMDB.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCMDB.Controllers
{
    public class DependenciesController : Controller
    {
        private readonly CmdbContext _context;

        public DependenciesController(CmdbContext context)
        {
            _context = context;
        }

        // GET: Dependencies
        public async Task<IActionResult> Index()
        {
            var dependencies = await _context.Dependencies
                .Include(d => d.SourceService)
                    .ThenInclude(s => s.Server)
                .Include(d => d.SourceService)
                    .ThenInclude(s => s.Application)
                .Include(d => d.TargetService)
                    .ThenInclude(s => s.Server)
                .Include(d => d.TargetService)
                    .ThenInclude(s => s.Application)
                .ToListAsync();

            var viewModel = new DependencyViewModel
            {
                Dependencies = dependencies,
                Services = await _context.Services
                    .Include(s => s.Server)
                    .Include(s => s.Application)
                    .ToListAsync()
            };

            return View(viewModel);
        }

        // GET: Dependencies/Create
        public async Task<IActionResult> Create()
        {
            var services = await _context.Services
                .Include(s => s.Server)
                .Include(s => s.Application)
                .ToListAsync();

            ViewData["SourceServiceId"] = new SelectList(
                services.Select(s => new {
                    Id = s.Id,
                    Name = $"{s.ServiceName} on {s.Server?.Hostname ?? "Unknown"}"
                }), "Id", "Name");

            ViewData["TargetServiceId"] = new SelectList(
                services.Select(s => new {
                    Id = s.Id,
                    Name = $"{s.ServiceName} on {s.Server?.Hostname ?? "Unknown"}"
                }), "Id", "Name");

            return View();
        }

        // POST: Dependencies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SourceServiceId,TargetServiceId,Description")] Dependency dependency)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dependency);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var services = await _context.Services
                .Include(s => s.Server)
                .Include(s => s.Application)
                .ToListAsync();

            ViewData["SourceServiceId"] = new SelectList(
                services.Select(s => new {
                    Id = s.Id,
                    Name = $"{s.ServiceName} on {s.Server?.Hostname ?? "Unknown"}"
                }), "Id", "Name", dependency.SourceServiceId);

            ViewData["TargetServiceId"] = new SelectList(
                services.Select(s => new {
                    Id = s.Id,
                    Name = $"{s.ServiceName} on {s.Server?.Hostname ?? "Unknown"}"
                }), "Id", "Name", dependency.TargetServiceId);

            return View(dependency);
        }

        // GET: Dependencies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dependency = await _context.Dependencies
                .Include(d => d.SourceService)
                    .ThenInclude(s => s.Server)
                .Include(d => d.TargetService)
                    .ThenInclude(s => s.Server)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (dependency == null)
            {
                return NotFound();
            }

            return View(dependency);
        }

        // POST: Dependencies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dependency = await _context.Dependencies.FindAsync(id);
            if (dependency != null)
            {
                _context.Dependencies.Remove(dependency);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}