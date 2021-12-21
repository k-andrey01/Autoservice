using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Autoservice.Data;
using Autoservice.Models;
using Microsoft.AspNetCore.Authorization;

namespace Autoservice.Controllers
{
    [Authorize]
    public class RequestsController : Controller
    {
        private readonly ServiceContext _context;

        public RequestsController(ServiceContext context)
        {
            _context = context;
        }

        // GET: Requests
        public async Task<IActionResult> Index()
        {
            var requests = _context.Requests
                .Include(r => r.ClientCars).Include(r => r.Clients).Include(r => r.Masters)
                .AsNoTracking();
            return View(await requests.ToListAsync());
        }

        // GET: Requests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Requests
                .Include(r => r.ClientCars)
                .Include(r => r.Clients)
                .Include(r => r.Masters)
                .FirstOrDefaultAsync(m => m.RequestID == id);
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        // GET: Requests/Create
        [Authorize(Roles = "Мастер")]
        public IActionResult Create()
        {
            ViewData["ClientCarId"] = new SelectList(_context.ClientCars, "ClientCarID", "Number");
            ViewData["ClientId"] = new SelectList(_context.Clients, "ID", "FirstMidName");
            ViewData["MasterId"] = new SelectList(_context.Masters, "ID", "FirstMidName");
            return View();
        }

        // POST: Requests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Мастер")]
        public async Task<IActionResult> Create([Bind("RequestID,ClientId,MasterId,ClientCarId,Date,Price")] Request request)
        {
            if (ModelState.IsValid)
            {
                _context.Add(request);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientCarId"] = new SelectList(_context.ClientCars, "ClientCarID", "Number", request.ClientCarId);
            ViewData["ClientId"] = new SelectList(_context.Clients, "ID", "FirstMidName", request.ClientId);
            ViewData["MasterId"] = new SelectList(_context.Masters, "ID", "FirstMidName", request.MasterId);
            return View(request);
        }

        // GET: Requests/Edit/5
        [Authorize(Roles = "Мастер")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Requests.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }
            ViewData["ClientCarId"] = new SelectList(_context.ClientCars, "ClientCarID", "Number", request.ClientCarId);
            ViewData["ClientId"] = new SelectList(_context.Clients, "ID", "FirstMidName", request.ClientId);
            ViewData["MasterId"] = new SelectList(_context.Masters, "ID", "FirstMidName", request.MasterId);
            return View(request);
        }

        // POST: Requests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Мастер")]
        public async Task<IActionResult> Edit(int id, [Bind("RequestID,ClientId,MasterId,ClientCarId,Date,Price")] Request request)
        {
            if (id != request.RequestID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(request);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequestExists(request.RequestID))
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
            ViewData["ClientCarId"] = new SelectList(_context.ClientCars, "ClientCarID", "Number", request.ClientCarId);
            ViewData["ClientId"] = new SelectList(_context.Clients, "ID", "FirstMidName", request.ClientId);
            ViewData["MasterId"] = new SelectList(_context.Masters, "ID", "FirstMidName", request.MasterId);
            return View(request);
        }

        // GET: Requests/Delete/5
        [Authorize(Roles = "Мастер")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Requests
                .Include(r => r.ClientCars)
                .Include(r => r.Clients)
                .Include(r => r.Masters)
                .FirstOrDefaultAsync(m => m.RequestID == id);
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        // POST: Requests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Мастер")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var request = await _context.Requests.FindAsync(id);
            _context.Requests.Remove(request);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequestExists(int id)
        {
            return _context.Requests.Any(e => e.RequestID == id);
        }
    }
}
