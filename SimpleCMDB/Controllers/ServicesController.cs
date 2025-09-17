using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SimpleCMDB.Data;
using SimpleCMDB.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCMDB.Controllers
{
    public class ServicesController : Controller
    {
        private readonly CmdbContext _context;

        public ServicesController(CmdbContext context)
        {
            _context = context;
        }

        // GET: Services
        public async Task<IActionResult> Index()
        {
            var services = await _context.Services
                .Include(s => s.Server)
                .Include(s => s.Application)
                .ToListAsync();
            return View(services);
        }

        // GET: Services/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _context.Services
                .Include(s => s.Server)
                .Include(s => s.Application)
                .Include(s => s.SourceDependencies)
                    .ThenInclude(d => d.TargetService)
                .Include(s => s.TargetDependencies)
                    .ThenInclude(d => d.SourceService)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        // GET: Services/Create
        public IActionResult Create()
        {
            ViewData["ApplicationId"] = new SelectList(_context.Applications, "Id", "Name");
            ViewData["ServerId"] = new SelectList(_context.Servers, "Id", "Hostname");
            return View();
        }

        // POST: Services/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ServiceName,ServerId,ApplicationId,Port,Protocol,Status,ProcessName,StartCommand,ConfigFile,LogFile")] Service service)
        {
            if (ModelState.IsValid)
            {
                _context.Add(service);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationId"] = new SelectList(_context.Applications, "Id", "Name", service.ApplicationId);
            ViewData["ServerId"] = new SelectList(_context.Servers, "Id", "Hostname", service.ServerId);
            return View(service);
        }

        // GET: Services/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _context.Services.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }
            ViewData["ApplicationId"] = new SelectList(_context.Applications, "Id", "Name", service.ApplicationId);
            ViewData["ServerId"] = new SelectList(_context.Servers, "Id", "Hostname", service.ServerId);
            return View(service);
        }

        // POST: Services/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ServiceName,ServerId,ApplicationId,Port,Protocol,Status,ProcessName,StartCommand,ConfigFile,LogFile")] Service service)
        {
            if (id != service.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    service.UpdatedAt = DateTime.UtcNow;
                    _context.Update(service);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceExists(service.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationId"] = new SelectList(_context.Applications, "Id", "Name", service.ApplicationId);
            ViewData["ServerId"] = new SelectList(_context.Servers, "Id", "Hostname", service.ServerId);
            return View(service);
        }

        // GET: Services/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _context.Services
                .Include(s => s.Application)
                .Include(s => s.Server)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        // POST: Services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var service = await _context.Services.FindAsync(id);
            if (service != null)
            {
                _context.Services.Remove(service);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceExists(int id)
        {
            return _context.Services.Any(e => e.Id == id);
        }
    }
}