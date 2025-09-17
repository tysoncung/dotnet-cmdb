using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleCMDB.Data;
using SimpleCMDB.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCMDB.Controllers
{
    public class ServersController : Controller
    {
        private readonly CmdbContext _context;

        public ServersController(CmdbContext context)
        {
            _context = context;
        }

        // GET: Servers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Servers.ToListAsync());
        }

        // GET: Servers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var server = await _context.Servers
                .Include(s => s.Services)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (server == null)
            {
                return NotFound();
            }

            return View(server);
        }

        // GET: Servers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Servers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Hostname,IpAddress,OsType,OsVersion,Environment,Status,Owner,Location,Notes,CpuCount,MemoryGb,DiskGb")] Server server)
        {
            if (ModelState.IsValid)
            {
                _context.Add(server);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(server);
        }

        // GET: Servers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var server = await _context.Servers.FindAsync(id);
            if (server == null)
            {
                return NotFound();
            }
            return View(server);
        }

        // POST: Servers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Hostname,IpAddress,OsType,OsVersion,Environment,Status,Owner,Location,Notes,CpuCount,MemoryGb,DiskGb")] Server server)
        {
            if (id != server.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    server.UpdatedAt = DateTime.UtcNow;
                    _context.Update(server);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServerExists(server.Id))
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
            return View(server);
        }

        // GET: Servers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var server = await _context.Servers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (server == null)
            {
                return NotFound();
            }

            return View(server);
        }

        // POST: Servers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var server = await _context.Servers.FindAsync(id);
            if (server != null)
            {
                _context.Servers.Remove(server);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServerExists(int id)
        {
            return _context.Servers.Any(e => e.Id == id);
        }
    }
}