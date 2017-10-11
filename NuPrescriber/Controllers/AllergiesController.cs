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
    public class AllergiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AllergiesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Allergies
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Allergies.Include(a => a.Ingredient).Include(a => a.Patient);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Allergies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allergy = await _context.Allergies
                .Include(a => a.Ingredient)
                .Include(a => a.Patient)
                .SingleOrDefaultAsync(m => m.AllergyId == id);
            if (allergy == null)
            {
                return NotFound();
            }

            return View(allergy);
        }

        // GET: Allergies/Create
        public IActionResult Create()
        {
            ViewData["IngredientId"] = new SelectList(_context.Ingredients, "IngredientId", "IngredientId");
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "PatientId");
            return View();
        }

        // POST: Allergies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AllergyId,PatientId,IngredientId,Type,Notes")] Allergy allergy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(allergy);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["IngredientId"] = new SelectList(_context.Ingredients, "IngredientId", "IngredientId", allergy.IngredientId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "PatientId", allergy.PatientId);
            return View(allergy);
        }

        // GET: Allergies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allergy = await _context.Allergies.SingleOrDefaultAsync(m => m.AllergyId == id);
            if (allergy == null)
            {
                return NotFound();
            }
            ViewData["IngredientId"] = new SelectList(_context.Ingredients, "IngredientId", "IngredientId", allergy.IngredientId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "PatientId", allergy.PatientId);
            return View(allergy);
        }

        // POST: Allergies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AllergyId,PatientId,IngredientId,Type,Notes")] Allergy allergy)
        {
            if (id != allergy.AllergyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(allergy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AllergyExists(allergy.AllergyId))
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
            ViewData["IngredientId"] = new SelectList(_context.Ingredients, "IngredientId", "IngredientId", allergy.IngredientId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "PatientId", allergy.PatientId);
            return View(allergy);
        }

        // GET: Allergies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allergy = await _context.Allergies
                .Include(a => a.Ingredient)
                .Include(a => a.Patient)
                .SingleOrDefaultAsync(m => m.AllergyId == id);
            if (allergy == null)
            {
                return NotFound();
            }

            return View(allergy);
        }

        // POST: Allergies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var allergy = await _context.Allergies.SingleOrDefaultAsync(m => m.AllergyId == id);
            _context.Allergies.Remove(allergy);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool AllergyExists(int id)
        {
            return _context.Allergies.Any(e => e.AllergyId == id);
        }
    }
}
