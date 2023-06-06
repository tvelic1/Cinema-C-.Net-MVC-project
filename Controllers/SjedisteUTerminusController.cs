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
    public class SjedisteUTerminusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SjedisteUTerminusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SjedisteUTerminus
        public async Task<IActionResult> Index()
        {
            return View(await _context.SjedisteUTerminu.ToListAsync());
        }

        // GET: SjedisteUTerminus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sjedisteUTerminu = await _context.SjedisteUTerminu
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sjedisteUTerminu == null)
            {
                return NotFound();
            }

            return View(sjedisteUTerminu);
        }

        // GET: SjedisteUTerminus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SjedisteUTerminus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BrojSjedista")] SjedisteUTerminu sjedisteUTerminu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sjedisteUTerminu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sjedisteUTerminu);
        }

        // GET: SjedisteUTerminus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sjedisteUTerminu = await _context.SjedisteUTerminu.FindAsync(id);
            if (sjedisteUTerminu == null)
            {
                return NotFound();
            }
            return View(sjedisteUTerminu);
        }

        // POST: SjedisteUTerminus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BrojSjedista")] SjedisteUTerminu sjedisteUTerminu)
        {
            if (id != sjedisteUTerminu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sjedisteUTerminu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SjedisteUTerminuExists(sjedisteUTerminu.Id))
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
            return View(sjedisteUTerminu);
        }

        // GET: SjedisteUTerminus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sjedisteUTerminu = await _context.SjedisteUTerminu
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sjedisteUTerminu == null)
            {
                return NotFound();
            }

            return View(sjedisteUTerminu);
        }

        // POST: SjedisteUTerminus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sjedisteUTerminu = await _context.SjedisteUTerminu.FindAsync(id);
            _context.SjedisteUTerminu.Remove(sjedisteUTerminu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SjedisteUTerminuExists(int id)
        {
            return _context.SjedisteUTerminu.Any(e => e.Id == id);
        }
    }
}
