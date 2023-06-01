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
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
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
    }
}
