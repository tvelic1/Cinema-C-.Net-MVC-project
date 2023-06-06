using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OOAD_G6_najjaci_tim.Data;
using OOAD_G6_najjaci_tim.Models;

namespace OOAD_G6_najjaci_tim.Controllers
{
    public class RacunsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RacunsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Racuns
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Racun.Include(r => r.KorisnikSaNalogom);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Racuns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var racun = await _context.Racun
                .Include(r => r.KorisnikSaNalogom)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (racun == null)
            {
                return NotFound();
            }

            return View(racun);
        }

        // GET: Racuns/Create
        public IActionResult Create()
        {
            ViewData["IdKorisnikSaNalogom"] = new SelectList(_context.KorisnikSaNalogom, "Id", "Id");
            return View();
        }

        // POST: Racuns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdKorisnikSaNalogom,BrojRacuna,CSC,DatumIsteka,StanjeRacuna")] Racun racun)
        {
            if (ModelState.IsValid)
            {
                _context.Add(racun);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdKorisnikSaNalogom"] = new SelectList(_context.KorisnikSaNalogom, "Id", "Id", racun.IdKorisnikSaNalogom);
            return View(racun);
        }

        // GET: Racuns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var racun = await _context.Racun.FindAsync(id);
            if (racun == null)
            {
                return NotFound();
            }
            ViewData["IdKorisnikSaNalogom"] = new SelectList(_context.KorisnikSaNalogom, "Id", "Id", racun.IdKorisnikSaNalogom);
            return View(racun);
        }

        // POST: Racuns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdKorisnikSaNalogom,BrojRacuna,CSC,DatumIsteka,StanjeRacuna")] Racun racun)
        {
            if (id != racun.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(racun);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RacunExists(racun.Id))
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
            ViewData["IdKorisnikSaNalogom"] = new SelectList(_context.KorisnikSaNalogom, "Id", "Id", racun.IdKorisnikSaNalogom);
            return View(racun);
        }

        // GET: Racuns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var racun = await _context.Racun
                .Include(r => r.KorisnikSaNalogom)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (racun == null)
            {
                return NotFound();
            }

            return View(racun);
        }

        // POST: Racuns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var racun = await _context.Racun.FindAsync(id);
            _context.Racun.Remove(racun);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RacunExists(int id)
        {
            return _context.Racun.Any(e => e.Id == id);
        }
    }
}
