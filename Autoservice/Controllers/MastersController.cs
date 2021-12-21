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
    public class MastersController : Controller
    {
        private readonly ServiceContext _context;

        public MastersController(ServiceContext context)
        {
            _context = context;
        }

        // GET: Masters
        /*public async Task<IActionResult> Index()
        {
            return View(await _context.Masters.ToListAsync());
        }*/

        public async Task<IActionResult> Index(int? id, int? requestID)
        {
            var viewModel = new MasterData();
            viewModel.Masters = await _context.Masters
          .Include(i => i.Requests)
            .ThenInclude(i => i.Clients)
          .Include(i => i.Requests)
            .ThenInclude(i => i.ClientCars)
          .AsNoTracking()
          .OrderBy(i => i.LastName)
          .ToListAsync();

            if (id != null)
            {
                ViewData["MasterID"] = id.Value;
                Master master = viewModel.Masters.Where(
                    i => i.ID == id.Value).Single();
                viewModel.Requests = master.Requests;
            }

            if (requestID != null)
            {
                ViewData["RequestID"] = requestID.Value;
                viewModel.Requests = viewModel.Requests.Where(
                    x => x.RequestID == requestID);
            }

            return View(viewModel);
        }

        // GET: Masters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var master = await _context.Masters
                .FirstOrDefaultAsync(m => m.ID == id);
            if (master == null)
            {
                return NotFound();
            }

            return View(master);
        }

        // GET: Masters/Create
        [Authorize(Roles = "Мастер")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Masters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Мастер")]
        public async Task<IActionResult> Create([Bind("ID,LastName,FirstMidName,Stage")] Master master)
        {
            if (ModelState.IsValid)
            {
                _context.Add(master);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(master);
        }

        // GET: Masters/Edit/5
        [Authorize(Roles = "Мастер")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var master = await _context.Masters.FindAsync(id);
            if (master == null)
            {
                return NotFound();
            }
            return View(master);
        }

        // POST: Masters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Мастер")]
        public async Task<IActionResult> Edit(int id, [Bind("ID,LastName,FirstMidName,Stage")] Master master)
        {
            if (id != master.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(master);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MasterExists(master.ID))
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
            return View(master);
        }

        // GET: Masters/Delete/5
        [Authorize(Roles = "Мастер")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var master = await _context.Masters
                .FirstOrDefaultAsync(m => m.ID == id);
            if (master == null)
            {
                return NotFound();
            }

            return View(master);
        }

        // POST: Masters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Мастер")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var master = await _context.Masters.FindAsync(id);
            _context.Masters.Remove(master);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MasterExists(int id)
        {
            return _context.Masters.Any(e => e.ID == id);
        }
    }
}
