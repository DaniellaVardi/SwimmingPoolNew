using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwimmingPoolNew.Models;
using System.Threading.Tasks;
using SwimmingPoolNew.Data;
using System.Linq;

namespace SwimmingPoolNew.Controllers
{
    public class TypeClassController : Controller
    {

        private readonly SwimmingPoolContext _context;

        public TypeClassController(SwimmingPoolContext context)
        {
            _context = context;
        }

        // GET: TypeClass
        public async Task<IActionResult> Index()
        {
            return _context.TypeClass != null ?
                        View(await _context.TypeClass.ToListAsync()) :
                        Problem("Entity set 'SwimmingPoolContext.TypeClass'  is null.");
        }

        // GET: TypeClass/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TypeClass == null)
            {
                return NotFound();
            }

            var typeClass = await _context.TypeClass
                .FirstOrDefaultAsync(m => m.ClassId == id);
            if (typeClass == null)
            {
                return NotFound();
            }

            return View(typeClass);
        }

        // GET: TypeClass/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeClass/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClassId,Name,Time")] TypeClass typeClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeClass);
        }

        // GET: TypeClass/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TypeClass == null)
            {
                return NotFound();
            }

            var typeClass = await _context.TypeClass.FindAsync(id);
            if (typeClass == null)
            {
                return NotFound();
            }
            return View(typeClass);
        }

        // POST: TypeClass/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Time")] TypeClass typeClass)
        {
            if (id != typeClass.ClassId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeClassExists(typeClass.ClassId))
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
            return View(typeClass);
        }

        // GET: TypeClass/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TypeClass == null)
            {
                return NotFound();
            }

            var typeClass = await _context.TypeClass
                .FirstOrDefaultAsync(m => m.ClassId == id);
            if (typeClass == null)
            {
                return NotFound();
            }

            return View(typeClass);
        }

        // POST: TypeClass/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TypeClass == null)
            {
                return Problem("Entity set 'SwimmingPoolContext.TypeClass'  is null.");
            }
            var typeClass = await _context.TypeClass.FindAsync(id);
            if (typeClass != null)
            {
                _context.TypeClass.Remove(typeClass);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeClassExists(int id)
        {
            return (_context.TypeClass?.Any(e => e.ClassId == id)).GetValueOrDefault();
        }
    }
}
