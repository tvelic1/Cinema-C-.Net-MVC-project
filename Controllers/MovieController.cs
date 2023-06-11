using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using OOAD_G6_najjaci_tim.Data;
using OOAD_G6_najjaci_tim.Models;

namespace OOAD_G6_najjaci_tim.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _cache;

        public MovieController(ApplicationDbContext context, IMemoryCache Memorycache)
        {
            _context = context; _cache=Memorycache;
        }

        // GET: Movie
        public async Task<IActionResult> Index()
        {
            return View(await _context.Film.ToListAsync());
        }
        public async Task<IActionResult> Proba(Zanr genre)
        {
            if (genre == null)
            {
              
                var filmovi = await _context.Film.ToListAsync();
                return View(filmovi);
            }
            else
            {
                Zanr selectedGenre = (Zanr)genre;

                var filmovi = await _context.Film
                    .Where(f => f.Zanr == genre)
                    .ToListAsync();

                return View(filmovi);
            }
        }
        public IActionResult Reserve()
        {
            return RedirectToAction("Create", "Rezervacija");

        }
        public async Task<IActionResult> AdminsPanel()
        {
            return View("AdminsPanel",await _context.Film.ToListAsync());
        }








        // GET: Movie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await _context.Film
                .FirstOrDefaultAsync(m => m.Id == id);
            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }

        // GET: Movie/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ime,Zanr,Trajanje,Ocjena")] Film film)
        {
            if (ModelState.IsValid)
            {
               
                if (_cache.TryGetValue("KorisnikEmail", out string email))
                {
                  
                    if (_cache.TryGetValue("KorisnikPassword", out string korisnikId))
                    {
                       
                        Administrator admin = await _context.Administrator.FirstOrDefaultAsync(a => a.Email == email && a.Password == korisnikId);
                        if (admin != null)
                        {
                            _context.Add(film);
                            await _context.SaveChangesAsync();
                            return RedirectToAction(nameof(AdminsPanel));
                        }
                        else {
                            _context.Add(film);
                            await _context.SaveChangesAsync();
                            return RedirectToAction(nameof(AdminsPanel));
                        }
                    }
                }

                
            }

            return View(film);
        }


        // GET: Movie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await _context.Film.FindAsync(id);
            if (film == null)
            {
                return NotFound();
            }
            return View(film);
        }

        // POST: Movie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ime,Zanr,Trajanje,Ocjena")] Film film)
        {
            if (id != film.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(film);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmExists(film.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(AdminsPanel));
            }
            return View(film);
        }

        // GET: Movie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await _context.Film
                .FirstOrDefaultAsync(m => m.Id == id);
            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }

        // POST: Movie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var film = await _context.Film.FindAsync(id);
            _context.Film.Remove(film);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(AdminsPanel));
        }

        private bool FilmExists(int id)
        {
            return _context.Film.Any(e => e.Id == id);
        }
    }
}
