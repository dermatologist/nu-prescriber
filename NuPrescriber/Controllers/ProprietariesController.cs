using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuPrescriber.Data;
using NuPrescriber.Models.PrescriptionViewModels;

namespace NuPrescriber.Controllers
{
    public class ProprietariesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProprietariesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Proprietaries
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Proprietaries.Include(p => p.Ingredient);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Proprietaries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proprietary = await _context.Proprietaries
                .Include(p => p.Ingredient)
                .SingleOrDefaultAsync(m => m.ProprietaryId == id);
            if (proprietary == null)
            {
                return NotFound();
            }

            return View(proprietary);
        }

        // GET: Proprietaries/Create
        public IActionResult Create()
        {
            ViewData["IngredientId"] = new SelectList(_context.Ingredients, "IngredientId", "IngredientId");
            return View();
        }

        // POST: Proprietaries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProprietaryId,Name,Manufacturer,Price,Notes,IngredientId")] Proprietary proprietary)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proprietary);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["IngredientId"] = new SelectList(_context.Ingredients, "IngredientId", "IngredientId", proprietary.IngredientId);
            return View(proprietary);
        }

        // GET: Proprietaries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proprietary = await _context.Proprietaries.SingleOrDefaultAsync(m => m.ProprietaryId == id);
            if (proprietary == null)
            {
                return NotFound();
            }
            ViewData["IngredientId"] = new SelectList(_context.Ingredients, "IngredientId", "IngredientId", proprietary.IngredientId);
            return View(proprietary);
        }

        // POST: Proprietaries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProprietaryId,Name,Manufacturer,Price,Notes,IngredientId")] Proprietary proprietary)
        {
            if (id != proprietary.ProprietaryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proprietary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProprietaryExists(proprietary.ProprietaryId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["IngredientId"] = new SelectList(_context.Ingredients, "IngredientId", "IngredientId", proprietary.IngredientId);
            return View(proprietary);
        }

        // GET: Proprietaries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proprietary = await _context.Proprietaries
                .Include(p => p.Ingredient)
                .SingleOrDefaultAsync(m => m.ProprietaryId == id);
            if (proprietary == null)
            {
                return NotFound();
            }

            return View(proprietary);
        }

        // POST: Proprietaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var proprietary = await _context.Proprietaries.SingleOrDefaultAsync(m => m.ProprietaryId == id);
            _context.Proprietaries.Remove(proprietary);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ProprietaryExists(int id)
        {
            return _context.Proprietaries.Any(e => e.ProprietaryId == id);
        }
    }
}
