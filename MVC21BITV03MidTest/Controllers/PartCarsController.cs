using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC21BITV03MidTest.Models;

namespace MVC21BITV03MidTest.Controllers
{
    public class PartCarsController : Controller
    {
        private readonly CarDealerContext _context;

        public PartCarsController(CarDealerContext context)
        {
            _context = context;
        }

        // GET: PartCars
        public async Task<IActionResult> Index()
        {
            var carDealerContext = _context.PartCar.Include(p => p.CarNav).Include(p => p.PartNav);
            return View(await carDealerContext.ToListAsync());
        }

        // GET: PartCars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partCar = await _context.PartCar
                .Include(p => p.CarNav)
                .Include(p => p.PartNav)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (partCar == null)
            {
                return NotFound();
            }

            return View(partCar);
        }

        // GET: PartCars/Create
        public IActionResult Create()
        {
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Id");
            ViewData["PartId"] = new SelectList(_context.Parts, "Id", "Id");
            return View();
        }

        // POST: PartCars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CarId,PartId")] PartCar partCar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(partCar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Id", partCar.CarId);
            ViewData["PartId"] = new SelectList(_context.Parts, "Id", "Id", partCar.PartId);
            return View(partCar);
        }

        // GET: PartCars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partCar = await _context.PartCar.FindAsync(id);
            if (partCar == null)
            {
                return NotFound();
            }
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Id", partCar.CarId);
            ViewData["PartId"] = new SelectList(_context.Parts, "Id", "Id", partCar.PartId);
            return View(partCar);
        }

        // POST: PartCars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CarId,PartId")] PartCar partCar)
        {
            if (id != partCar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(partCar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartCarExists(partCar.Id))
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
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Id", partCar.CarId);
            ViewData["PartId"] = new SelectList(_context.Parts, "Id", "Id", partCar.PartId);
            return View(partCar);
        }

        // GET: PartCars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partCar = await _context.PartCar
                .Include(p => p.CarNav)
                .Include(p => p.PartNav)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (partCar == null)
            {
                return NotFound();
            }

            return View(partCar);
        }

        // POST: PartCars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var partCar = await _context.PartCar.FindAsync(id);
            if (partCar != null)
            {
                _context.PartCar.Remove(partCar);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartCarExists(int id)
        {
            return _context.PartCar.Any(e => e.Id == id);
        }
    }
}
