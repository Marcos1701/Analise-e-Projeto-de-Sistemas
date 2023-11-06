#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projetinho.Models;

namespace Projetinho.Controllers
{
    public class GeneralBooksController : Controller
    {
        private readonly MyDbContext _context;

        public GeneralBooksController(MyDbContext context)
        {
            _context = context;
        }

        // GET: GeneralBooks
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.GeneralBooks.Include(g => g.Catalog).Include(g => g.Libraian).Include(g => g.Member);
            return View(await myDbContext.ToListAsync());
        }

        // GET: GeneralBooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var generalBook = await _context.GeneralBooks
                .Include(g => g.Catalog)
                .Include(g => g.Libraian)
                .Include(g => g.Member)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (generalBook == null)
            {
                return NotFound();
            }

            return View(generalBook);
        }

        // GET: GeneralBooks/Create
        public IActionResult Create()
        {
            ViewData["CatalogId"] = new SelectList(_context.Catalogs, "Id", "Authorname");
            ViewData["LibraianId"] = new SelectList(_context.Libraians, "Id", "Name");
            ViewData["MemberId"] = new SelectList(_context.Members, "Id", "Name");
            return View();
        }

        // POST: GeneralBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MemberId,Id,Authorname,Bookname,Bookquantity,CatalogId,LibraianId")] GeneralBook generalBook)
        {
            if (ModelState.IsValid)
            {
                if (valuesExists(generalBook.Authorname, generalBook.Bookname, null))
                {
                    ModelState.AddModelError("Authorname", "Combinação de autor e nome já existente.");
                    return View(generalBook);
                }

                _context.Add(generalBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CatalogId"] = new SelectList(_context.Catalogs, "Id", "Authorname", generalBook.CatalogId);
            ViewData["LibraianId"] = new SelectList(_context.Libraians, "Id", "Name", generalBook.LibraianId);
            ViewData["MemberId"] = new SelectList(_context.Members, "Id", "Name", generalBook.MemberId);
            return View(generalBook);
        }

        // GET: GeneralBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var generalBook = await _context.GeneralBooks.FindAsync(id);
            if (generalBook == null)
            {
                return NotFound();
            }
            ViewData["CatalogId"] = new SelectList(_context.Catalogs, "Id", "Authorname", generalBook.CatalogId);
            ViewData["LibraianId"] = new SelectList(_context.Libraians, "Id", "Name", generalBook.LibraianId);
            ViewData["MemberId"] = new SelectList(_context.Members, "Id", "Name", generalBook.MemberId);
            return View(generalBook);
        }

        // POST: GeneralBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MemberId,Id,Authorname,Bookname,Bookquantity,CatalogId,LibraianId")] GeneralBook generalBook)
        {
            if (id != generalBook.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (valuesExists(generalBook.Authorname, generalBook.Bookname, id))
                {
                    ModelState.AddModelError("Authorname", "Combinação de autor e nome já existente.");
                    return View(generalBook);
                }

                try
                {
                    _context.Update(generalBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GeneralBookExists(generalBook.Id))
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
            ViewData["CatalogId"] = new SelectList(_context.Catalogs, "Id", "Authorname", generalBook.CatalogId);
            ViewData["LibraianId"] = new SelectList(_context.Libraians, "Id", "Name", generalBook.LibraianId);
            ViewData["MemberId"] = new SelectList(_context.Members, "Id", "Name", generalBook.MemberId);
            return View(generalBook);
        }

        // GET: GeneralBooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var generalBook = await _context.GeneralBooks
                .Include(g => g.Catalog)
                .Include(g => g.Libraian)
                .Include(g => g.Member)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (generalBook == null)
            {
                return NotFound();
            }

            return View(generalBook);
        }

        // POST: GeneralBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var generalBook = await _context.GeneralBooks.FindAsync(id);
            _context.GeneralBooks.Remove(generalBook);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GeneralBookExists(int id)
        {
            return _context.GeneralBooks.Any(e => e.Id == id);
        }

        private bool valuesExists(string par1, string par2, int? id)
        {
            bool values = _context.GeneralBooks.Any(
                generalBook => generalBook.Authorname == par1 && generalBook.Bookname == par2 && generalBook.Id != id);
            return values;
        }
    }
}
