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
    public class PrescribedDrugsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PrescribedDrugsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: PrescribedDrugs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PrescribedDrugs.Include(p => p.Prescription).Include(p => p.Proprietary);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PrescribedDrugs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prescribedDrug = await _context.PrescribedDrugs
                .Include(p => p.Prescription)
                .Include(p => p.Proprietary)
                .SingleOrDefaultAsync(m => m.PrescribedDrugId == id);
            if (prescribedDrug == null)
            {
                return NotFound();
            }

            return View(prescribedDrug);
        }

        // GET: PrescribedDrugs/Create
        public IActionResult Create()
        {
            ViewData["PrescriptionId"] = new SelectList(_context.Prescriptions, "PrescriptionId", "Date");
            ViewData["ProprietaryId"] = new SelectList(_context.Proprietaries, "ProprietaryId", "Name");
            return View();
        }

        // POST: PrescribedDrugs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PrescribedDrugId,Dose,Duration,Frequency,Instructions,PrescriptionId,ProprietaryId")] PrescribedDrug prescribedDrug)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prescribedDrug);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["PrescriptionId"] = new SelectList(_context.Prescriptions, "PrescriptionId", "PrescriptionId", prescribedDrug.PrescriptionId);
            ViewData["ProprietaryId"] = new SelectList(_context.Proprietaries, "ProprietaryId", "ProprietaryId", prescribedDrug.ProprietaryId);
            return View(prescribedDrug);
        }

        // GET: PrescribedDrugs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prescribedDrug = await _context.PrescribedDrugs.SingleOrDefaultAsync(m => m.PrescribedDrugId == id);
            if (prescribedDrug == null)
            {
                return NotFound();
            }
            ViewData["PrescriptionId"] = new SelectList(_context.Prescriptions, "PrescriptionId", "PrescriptionId", prescribedDrug.PrescriptionId);
            ViewData["ProprietaryId"] = new SelectList(_context.Proprietaries, "ProprietaryId", "ProprietaryId", prescribedDrug.ProprietaryId);
            return View(prescribedDrug);
        }

        // POST: PrescribedDrugs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PrescribedDrugId,Dose,Duration,Frequency,Instructions,PrescriptionId,ProprietaryId")] PrescribedDrug prescribedDrug)
        {
            if (id != prescribedDrug.PrescribedDrugId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prescribedDrug);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrescribedDrugExists(prescribedDrug.PrescribedDrugId))
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
            ViewData["PrescriptionId"] = new SelectList(_context.Prescriptions, "PrescriptionId", "PrescriptionId", prescribedDrug.PrescriptionId);
            ViewData["ProprietaryId"] = new SelectList(_context.Proprietaries, "ProprietaryId", "ProprietaryId", prescribedDrug.ProprietaryId);
            return View(prescribedDrug);
        }

        // GET: PrescribedDrugs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prescribedDrug = await _context.PrescribedDrugs
                .Include(p => p.Prescription)
                .Include(p => p.Proprietary)
                .SingleOrDefaultAsync(m => m.PrescribedDrugId == id);
            if (prescribedDrug == null)
            {
                return NotFound();
            }

            return View(prescribedDrug);
        }

        // POST: PrescribedDrugs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prescribedDrug = await _context.PrescribedDrugs.SingleOrDefaultAsync(m => m.PrescribedDrugId == id);
            _context.PrescribedDrugs.Remove(prescribedDrug);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PrescribedDrugExists(int id)
        {
            return _context.PrescribedDrugs.Any(e => e.PrescribedDrugId == id);
        }
    }
}
