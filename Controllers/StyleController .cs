using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwimmingPoolNew.Models;
using System.Threading.Tasks;
using SwimmingPoolNew.Data;
using System.Linq;

namespace SwimmingPoolNew.Controllers
{
    public class StyleController : Controller
    {

        private readonly SwimmingPoolContext _context;

        public StyleController(SwimmingPoolContext context)
        {
            _context = context;
        }

        // GET: TypeClass
        public async Task<IActionResult> Index()
        {
            return _context.Style != null ?
                        View(await _context.Style.ToListAsync()) :
                        Problem("Entity set 'SwimmingPoolContext.Style'  is null.");
        }

        // GET: TypeClass/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Style == null)
            {
                return NotFound();
            }

            var styles = await _context.Style
                .FirstOrDefaultAsync(m => m.StyleId == id);
            if (styles == null)
            {
                return NotFound();
            }

            return View(styles);
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
        public async Task<IActionResult> Create([Bind("StyleId,Name")] Style style)
        {
            if (ModelState.IsValid)
            {
                _context.Add(style);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(style);
        }

        // GET: TypeClass/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Style == null)
            {
                return NotFound();
            }

            var style = await _context.Style.FindAsync(id);
            if (style == null)
            {
                return NotFound();
            }
            return View(style);
        }

        // POST: TypeClass/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StyleId,Name")] Style style)
        {
            if (id != style.StyleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(style);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeClassExists(style.StyleId))
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
            return View(style);
        }

        // GET: TypeClass/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Style == null)
            {
                return NotFound();
            }

            var style = await _context.Style
                .FirstOrDefaultAsync(m => m.StyleId == id);
            if (style == null)
            {
                return NotFound();
            }

            return View(style);
        }

        // POST: TypeClass/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TypeClass == null)
            {
                return Problem("Entity set 'SwimmingPoolContext.Style'  is null.");
            }
            var style = await _context.TypeClass.FindAsync(id);
            if (style != null)
            {
                _context.TypeClass.Remove(style);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeClassExists(int id)
        {
            return (_context.Style?.Any(e => e.StyleId == id)).GetValueOrDefault();
        }
    }
}
