using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? page)
        {

            ViewData["CurrentSort"] = sortOrder;
            ViewData["StatusSortParm"] = String.IsNullOrEmpty(sortOrder) ? "stat_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var proprietaries = _context.Proprietaries.Include(s => s.IngredientsProprietaries).AsQueryable();


            if (!String.IsNullOrEmpty(searchString))
            {
                proprietaries = proprietaries.Where(s => s.Name.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "stat_desc":
                    proprietaries = proprietaries.OrderByDescending(s => s.Name);
                    break;
                case "Date":
                    proprietaries = proprietaries.OrderBy(s => s.Price);
                    break;
                case "date_desc":
                    proprietaries = proprietaries.OrderByDescending(s => s.Price);
                    break;
                default:
                    proprietaries = proprietaries.OrderBy(s => s.Name);
                    break;
            }
            int pageSize = 15;
            return View(await PaginatedList<Proprietary>.CreateAsync(proprietaries.AsNoTracking(), page ?? 1, pageSize));

            //var applicationDbContext = _context.Proprietaries.Include(p => p.IngredientsProprietaries);
            //return View(await applicationDbContext.ToListAsync());
        }

        // GET: Proprietaries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proprietary = await _context.Proprietaries
                .Include(p => p.IngredientsProprietaries)
                .SingleOrDefaultAsync(m => m.ProprietaryId == id);
            if (proprietary == null)
            {
                return NotFound();
            }

            if (proprietary.IngredientsProprietaries.Any())
            {
                var selectedIngredientsIds = proprietary.IngredientsProprietaries.Select(x => x.IngredientId);
                ViewData["SelectedIngredients"] = _context.Ingredients.Where(i => selectedIngredientsIds.Contains(i.IngredientId)).Select(ing => ing.Name).ToList();
            }
            
            return View(proprietary);
        }
        // GET: Proprietaries/Create
        public IActionResult Create()
        {
            var proprietary = new Proprietary();
            proprietary.IngredientsProprietaries = new List<IngredientProprietary>();
            AssignIngredients(proprietary);

            return View();
        }

        // POST: Proprietaries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProprietaryId,Name,Manufacturer,Price,Notes")] Proprietary proprietary, string[] selectedIngredients)
        {
            if (selectedIngredients != null)
            {
                proprietary.IngredientsProprietaries = new List<IngredientProprietary>();
                foreach (var ingredient in selectedIngredients)
                {
                    var ingredientToAdd = new IngredientProprietary() { IngredientId = int.Parse(ingredient), ProprietaryId = proprietary.ProprietaryId };
                    proprietary.IngredientsProprietaries.Add(ingredientToAdd);
                }
            }
            if (ModelState.IsValid)
            {
                _context.Add(proprietary);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            AssignIngredients(proprietary);
            return View(proprietary);
        }

        // GET: Proprietaries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proprietary = await _context.Proprietaries
                .Include(p => p.IngredientsProprietaries)
                .SingleOrDefaultAsync(m => m.ProprietaryId == id);
            if (proprietary == null)
            {
                return NotFound();
            }

            AssignIngredients(proprietary);

            return View(proprietary);
        }
        // POST: Proprietaries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id,  string[] selectedIngredients)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proprietaryToUpdate = await _context.Proprietaries
                .Include(p => p.IngredientsProprietaries)
                .SingleOrDefaultAsync(i => i.ProprietaryId == id);

            if (ModelState.IsValid)
            {
                UpdateIngredients(proprietaryToUpdate, selectedIngredients);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProprietaryExists(proprietaryToUpdate.ProprietaryId))
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
            UpdateIngredients(proprietaryToUpdate, selectedIngredients);
            AssignIngredients(proprietaryToUpdate);

            return View(proprietaryToUpdate);
        }
        // GET: Proprietaries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proprietary = await _context.Proprietaries
                .Include(p => p.IngredientsProprietaries)
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

        private void AssignIngredients(Proprietary proprietary)
        {
            var ingredients = _context.Ingredients;
            var ingredientsForProprietary = new HashSet<int>(proprietary.IngredientsProprietaries.Select(i => i.IngredientId));
            var viewmodel = new List<IngredientAssignment>();
            foreach (var ingredient in ingredients)
            {
                viewmodel.Add(new IngredientAssignment
                {
                    Id = ingredient.IngredientId,
                    Name = ingredient.Name,
                    Quantity = ingredient.Quantity,
                    Assigned = ingredientsForProprietary.Contains(ingredient.IngredientId)
                });
            }
            ViewData["Ingredients"] = viewmodel;
        }

        private void UpdateIngredients(Proprietary proprietary, string[] selectedIngredients)
        {
            if (selectedIngredients == null)
            {
                proprietary.IngredientsProprietaries = new List<IngredientProprietary>();
            }

            var selectedIngredientsHashSet = new HashSet<string>(selectedIngredients);
            var proprietaryIngredients = new HashSet<int>(proprietary.IngredientsProprietaries.Select(ip => ip.IngredientId));

            foreach (var ingredient in _context.Ingredients)
            {
                if (selectedIngredientsHashSet.Contains(ingredient.IngredientId.ToString()))
                {
                    if (!proprietaryIngredients.Contains(ingredient.IngredientId))
                    {
                        proprietary.IngredientsProprietaries.Add(new IngredientProprietary
                        {
                            IngredientId = ingredient.IngredientId,
                            ProprietaryId = proprietary.ProprietaryId
                        });
                    }
                }
                else
                {
                    if (proprietaryIngredients.Contains(ingredient.IngredientId))
                    {
                        var ingredientToRemove =
                            proprietary.IngredientsProprietaries.SingleOrDefault(ip =>
                                ip.IngredientId == ingredient.IngredientId);
                        if (ingredientToRemove != null)
                        {
                            _context.Remove(ingredientToRemove);
                        }
                    }
                }
            }
        }
    }
}
