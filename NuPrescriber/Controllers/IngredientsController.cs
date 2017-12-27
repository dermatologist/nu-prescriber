using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuPrescriber.Data;
using NuPrescriber.Models.PrescriptionViewModels;

namespace NuPrescriber.Controllers
{
    public class IngredientsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IngredientsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Ingredients
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

            var ingredients = from s in _context.Ingredients
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                ingredients = ingredients.Where(s => s.Name.Contains(searchString));

            }

            switch (sortOrder)
            {
                case "stat_desc":
                    ingredients = ingredients.OrderByDescending(s => s.Name);
                    break;
                case "Date":
                    ingredients = ingredients.OrderBy(s => s.Quantity);
                    break;
                case "date_desc":
                    ingredients = ingredients.OrderByDescending(s => s.Quantity);
                    break;
                default:
                    ingredients = ingredients.OrderBy(s => s.Name);
                    break;
            }
            int pageSize = 15;
            return View(await PaginatedList<Ingredient>.CreateAsync(ingredients.AsNoTracking(), page ?? 1, pageSize));
        }

        // GET: Ingredients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredient = await _context.Ingredients
                .SingleOrDefaultAsync(m => m.IngredientId == id);
            if (ingredient == null)
            {
                return NotFound();
            }

            return View(ingredient);
        }
        // GET: Ingredients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ingredients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IngredientId,Name,Quantity,Notes")] Ingredient ingredient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ingredient);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(ingredient);
        }
        // GET: Ingredients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredient = await _context.Ingredients.SingleOrDefaultAsync(m => m.IngredientId == id);
            if (ingredient == null)
            {
                return NotFound();
            }
            return View(ingredient);
        }

        // POST: Ingredients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IngredientId,Name,Quantity,Notes")] Ingredient ingredient)
        {
            if (id != ingredient.IngredientId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ingredient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IngredientExists(ingredient.IngredientId))
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
            return View(ingredient);
        }
        // GET: Ingredients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredient = await _context.Ingredients
                .SingleOrDefaultAsync(m => m.IngredientId == id);
            if (ingredient == null)
            {
                return NotFound();
            }

            return View(ingredient);
        }
        // POST: Ingredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ingredient = await _context.Ingredients.SingleOrDefaultAsync(m => m.IngredientId == id);
            _context.Ingredients.Remove(ingredient);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool IngredientExists(int id)
        {
            return _context.Ingredients.Any(e => e.IngredientId == id);
        }
    }
}
