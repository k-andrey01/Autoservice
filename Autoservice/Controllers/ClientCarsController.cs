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
    public class ClientCarsController : Controller
    {
        private readonly ServiceContext _context;

        public ClientCarsController(ServiceContext context)
        {
            _context = context;
        }

        // GET: ClientCars
        public async Task<IActionResult> Index()
        {
            var cars = _context.ClientCars
                .Include(r => r.Cars)
                .AsNoTracking();
            return View(await cars.ToListAsync());
        }

        // GET: ClientCars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientCar = await _context.ClientCars
                .Include(c => c.Cars)
                .FirstOrDefaultAsync(m => m.ClientCarID == id);
            if (clientCar == null)
            {
                return NotFound();
            }

            return View(clientCar);
        }

        // GET: ClientCars/Create
        [Authorize(Roles = "Мастер")]
        public IActionResult Create()
        {
            ViewData["CarID"] = new SelectList(_context.Cars, "CarID", "Model");
            return View();
        }

        // POST: ClientCars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Мастер")]
        public async Task<IActionResult> Create([Bind("ClientCarID,CarID,Number,Year")] ClientCar clientCar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientCar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarID"] = new SelectList(_context.Cars, "CarID", "Model", clientCar.CarID);
            return View(clientCar);
        }

        // GET: ClientCars/Edit/5
        [Authorize(Roles = "Мастер")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientCar = await _context.ClientCars.FindAsync(id);
            if (clientCar == null)
            {
                return NotFound();
            }
            ViewData["CarID"] = new SelectList(_context.Cars, "CarID", "Model", clientCar.CarID);
            return View(clientCar);
        }

        // POST: ClientCars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Мастер")]
        public async Task<IActionResult> Edit(int id, [Bind("ClientCarID,CarID,Number,Year")] ClientCar clientCar)
        {
            if (id != clientCar.ClientCarID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientCar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientCarExists(clientCar.ClientCarID))
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
            ViewData["CarID"] = new SelectList(_context.Cars, "CarID", "Model", clientCar.CarID);
            return View(clientCar);
        }

        // GET: ClientCars/Delete/5
        [Authorize(Roles = "Мастер")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientCar = await _context.ClientCars
                .Include(c => c.Cars)
                .FirstOrDefaultAsync(m => m.ClientCarID == id);
            if (clientCar == null)
            {
                return NotFound();
            }

            return View(clientCar);
        }

        // POST: ClientCars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Мастер")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientCar = await _context.ClientCars.FindAsync(id);
            _context.ClientCars.Remove(clientCar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientCarExists(int id)
        {
            return _context.ClientCars.Any(e => e.ClientCarID == id);
        }
    }
}
