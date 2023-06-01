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
    public class TicketController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TicketController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ticket
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Karta.Include(k => k.Film).Include(k => k.KorisnikSaNalogom).Include(k => k.Rezervacija).Include(k => k.SjedisteUTerminu);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Ticket/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var karta = await _context.Karta
                .Include(k => k.Film)
                .Include(k => k.KorisnikSaNalogom)
                .Include(k => k.Rezervacija)
                .Include(k => k.SjedisteUTerminu)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (karta == null)
            {
                return NotFound();
            }

            return View(karta);
        }

        // GET: Ticket/Create
        public IActionResult Create()
        {
            ViewData["IdFilm"] = new SelectList(_context.Film, "Id", "Id");
            ViewData["IdKorisnikSaNalogom"] = new SelectList(_context.KorisnikSaNalogom, "Id", "Id");
            ViewData["IdRezervacija"] = new SelectList(_context.Rezervacija, "Id", "Id");
            ViewData["Id"] = new SelectList(_context.SjedisteUTerminu, "Id", "Id");
            return View();
        }

        // POST: Ticket/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdKorisnikSaNalogom,IdFilm,IdRezervacija")] Karta karta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(karta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdFilm"] = new SelectList(_context.Film, "Id", "Id", karta.IdFilm);
            ViewData["IdKorisnikSaNalogom"] = new SelectList(_context.KorisnikSaNalogom, "Id", "Id", karta.IdKorisnikSaNalogom);
            ViewData["IdRezervacija"] = new SelectList(_context.Rezervacija, "Id", "Id", karta.IdRezervacija);
            ViewData["Id"] = new SelectList(_context.SjedisteUTerminu, "Id", "Id", karta.Id);
            return View(karta);
        }

        // GET: Ticket/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var karta = await _context.Karta.FindAsync(id);
            if (karta == null)
            {
                return NotFound();
            }
            ViewData["IdFilm"] = new SelectList(_context.Film, "Id", "Id", karta.IdFilm);
            ViewData["IdKorisnikSaNalogom"] = new SelectList(_context.KorisnikSaNalogom, "Id", "Id", karta.IdKorisnikSaNalogom);
            ViewData["IdRezervacija"] = new SelectList(_context.Rezervacija, "Id", "Id", karta.IdRezervacija);
            ViewData["Id"] = new SelectList(_context.SjedisteUTerminu, "Id", "Id", karta.Id);
            return View(karta);
        }

        // POST: Ticket/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdKorisnikSaNalogom,IdFilm,IdRezervacija")] Karta karta)
        {
            if (id != karta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(karta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KartaExists(karta.Id))
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
            ViewData["IdFilm"] = new SelectList(_context.Film, "Id", "Id", karta.IdFilm);
            ViewData["IdKorisnikSaNalogom"] = new SelectList(_context.KorisnikSaNalogom, "Id", "Id", karta.IdKorisnikSaNalogom);
            ViewData["IdRezervacija"] = new SelectList(_context.Rezervacija, "Id", "Id", karta.IdRezervacija);
            ViewData["Id"] = new SelectList(_context.SjedisteUTerminu, "Id", "Id", karta.Id);
            return View(karta);
        }

        // GET: Ticket/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var karta = await _context.Karta
                .Include(k => k.Film)
                .Include(k => k.KorisnikSaNalogom)
                .Include(k => k.Rezervacija)
                .Include(k => k.SjedisteUTerminu)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (karta == null)
            {
                return NotFound();
            }

            return View(karta);
        }

        // POST: Ticket/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var karta = await _context.Karta.FindAsync(id);
            _context.Karta.Remove(karta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KartaExists(int id)
        {
            return _context.Karta.Any(e => e.Id == id);
        }
    }
}
