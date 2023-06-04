using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using OOAD_G6_najjaci_tim.Data;
using OOAD_G6_najjaci_tim.Models;

namespace OOAD_G6_najjaci_tim.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _cache;

        

        public UserController(ApplicationDbContext context, IMemoryCache memoryCache)
        {
            _context = context; _cache = memoryCache;
        }

        // GET: User
        public async Task<IActionResult> Index()
        {
            return View(await _context.KorisnikSaNalogom.ToListAsync());
        }

        // GET: User/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var korisnikSaNalogom = await _context.KorisnikSaNalogom
                .FirstOrDefaultAsync(m => m.Id == id);
            if (korisnikSaNalogom == null)
            {
                return NotFound();
            }

            return View(korisnikSaNalogom);
        }

        // GET: User/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Password,Email,ImaPravoNaPopust,Id,Ime,Prezime,DateRodjenja,BrojTelefona")] KorisnikSaNalogom korisnikSaNalogom)
        {
            if (ModelState.IsValid)
            {
                _context.Add(korisnikSaNalogom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(korisnikSaNalogom);
        }

        // GET: User/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var korisnikSaNalogom = await _context.KorisnikSaNalogom.FindAsync(id);
            if (korisnikSaNalogom == null)
            {
                return NotFound();
            }
            return View(korisnikSaNalogom);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Password,Email,ImaPravoNaPopust,Id,Ime,Prezime,DateRodjenja,BrojTelefona")] KorisnikSaNalogom korisnikSaNalogom)
        {
            if (id != korisnikSaNalogom.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(korisnikSaNalogom);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KorisnikSaNalogomExists(korisnikSaNalogom.Id))
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
            return View(korisnikSaNalogom);
        }
       

        public async Task<IActionResult> Loginn([Bind("Password,Email")] KorisnikSaNalogom korisnikSaNalogom)
        {
            if (ModelState.IsValid)
            {
                // Provjeri podatke za prijavu u bazi podataka
                KorisnikSaNalogom korisnik = await _context.KorisnikSaNalogom
                    .FirstOrDefaultAsync(kr => kr.Email == korisnikSaNalogom.Email && kr.Password == korisnikSaNalogom.Password);

                if (korisnik != null)
                {
                    _cache.Set("KorisnikId", korisnik.Id, TimeSpan.FromDays(30)); // Primer: keširanje na 30 dana

                    // Preusmjeri na Index akciju u HomeControlleru
                    return RedirectToAction("Index", "Movie");
                }
                else
                {
                    // Pogrešni podaci za prijavu, dodaj poruku o grešci u ModelState
                    ModelState.AddModelError(string.Empty, "Neispravni podaci za prijavu");
                }
            }

            // Ako podaci nisu ispravni ili dolazi do greške, ponovno prikaži Login1 view
            return View();
        }




        // GET: User/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var korisnikSaNalogom = await _context.KorisnikSaNalogom
                .FirstOrDefaultAsync(m => m.Id == id);
            if (korisnikSaNalogom == null)
            {
                return NotFound();
            }

            return View(korisnikSaNalogom);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var korisnikSaNalogom = await _context.KorisnikSaNalogom.FindAsync(id);
            _context.KorisnikSaNalogom.Remove(korisnikSaNalogom);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KorisnikSaNalogomExists(int id)
        {
            return _context.KorisnikSaNalogom.Any(e => e.Id == id);
        }
    
    public IActionResult Login1()
    {
            return View("Login1");
    
    }
 
    private bool ProvjeriPodatke(string username, string password)
        {
            var user = _context.KorisnikSaNalogom.FirstOrDefault(u => u.Email == username && u.Password == password);

            if (user != null)
            {
                // Ako korisnik postoji u bazi podataka, vraćamo true
                return true;
            }

            // Ako korisnik ne postoji ili podaci nisu ispravni, vraćamo false
            return false;
        }



    }
}
