using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GlobalSolution.Models;

namespace dbo.tblRadar.Controllers
{
    public class RadarController : Controller
    {
        private readonly Contexto _context;

        public RadarController(Contexto context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return _context.Radar != null ?
                        View(await _context.Radar.ToListAsync()) :
                        Problem("Entity set 'Contexto.Radar'  is null.");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Radar == null)
            {
                return NotFound();
            }

            var radar = await _context.Radar
                .FirstOrDefaultAsync(m => m.ID == id);
            if (radar == null)
            {
                return NotFound();
            }

            return View(radar);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome, Cidade, ID, Km")] Radar radar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(radar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(radar);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Radar == null)
            {
                return NotFound();
            }

            var radar = await _context.Radar.FindAsync(id);
            if (radar == null)
            {
                return NotFound();
            }
            return View(radar);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nome, Cidade, ID, Km")] Radar radar)
        {
            if (id != radar.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(radar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RadarExists(radar.ID))
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
            return View(radar);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Radar == null)
            {
                return NotFound();
            }

            var radar = await _context.Radar
                .FirstOrDefaultAsync(m => m.ID == id);
            if (radar == null)
            {
                return NotFound();
            }

            return View(radar);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Radar == null)
            {
                return Problem("Entity set 'Contexto.Radar'  is null.");
            }
            var radar = await _context.Radar.FindAsync(id);
            if (radar != null)
            {
                _context.Radar.Remove(radar);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RadarExists(int id)
        {
            return (_context.Radar?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}