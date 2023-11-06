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
    public class ReferenceBooksController : Controller
    {
        private readonly MyDbContext _context;

        public ReferenceBooksController(MyDbContext context)
        {
            _context = context;
        }

        // GET: ReferenceBooks
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.ReferenceBooks.Include(r => r.Catalog).Include(r => r.Libraian);
            return View(await myDbContext.ToListAsync());
        }

        // GET: ReferenceBooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var referenceBook = await _context.ReferenceBooks
                .Include(r => r.Catalog)
                .Include(r => r.Libraian)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (referenceBook == null)
            {
                return NotFound();
            }

            return View(referenceBook);
        }

        // GET: ReferenceBooks/Create
        public IActionResult Create()
        {
            ViewData["CatalogId"] = new SelectList(_context.Catalogs, "Id", "Authorname");
            ViewData["LibraianId"] = new SelectList(_context.Libraians, "Id", "Name");
            return View();
        }

        // POST: ReferenceBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Authorname,Bookname,Bookquantity,CatalogId,LibraianId")] ReferenceBook referenceBook)
        {
            if (ModelState.IsValid)
            {
                if (valuesExists(referenceBook.Authorname, referenceBook.Bookname, null))
                {
                    ModelState.AddModelError("Authorname", "Combinação de autor e nome já existente.");
                    return View(referenceBook);
                }

                _context.Add(referenceBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CatalogId"] = new SelectList(_context.Catalogs, "Id", "Authorname", referenceBook.CatalogId);
            ViewData["LibraianId"] = new SelectList(_context.Libraians, "Id", "Name", referenceBook.LibraianId);
            return View(referenceBook);
        }

        // GET: ReferenceBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var referenceBook = await _context.ReferenceBooks.FindAsync(id);
            if (referenceBook == null)
            {
                return NotFound();
            }
            ViewData["CatalogId"] = new SelectList(_context.Catalogs, "Id", "Authorname", referenceBook.CatalogId);
            ViewData["LibraianId"] = new SelectList(_context.Libraians, "Id", "Name", referenceBook.LibraianId);
            return View(referenceBook);
        }

        // POST: ReferenceBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Authorname,Bookname,Bookquantity,CatalogId,LibraianId")] ReferenceBook referenceBook)
        {
            if (id != referenceBook.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (valuesExists(referenceBook.Authorname, referenceBook.Bookname, referenceBook.Id))
                {
                    ModelState.AddModelError("Authorname", "Combinação de autor e nome já existente.");
                    return View(referenceBook);
                }

                try
                {
                    _context.Update(referenceBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReferenceBookExists(referenceBook.Id))
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
            ViewData["CatalogId"] = new SelectList(_context.Catalogs, "Id", "Authorname", referenceBook.CatalogId);
            ViewData["LibraianId"] = new SelectList(_context.Libraians, "Id", "Name", referenceBook.LibraianId);
            return View(referenceBook);
        }

        // GET: ReferenceBooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var referenceBook = await _context.ReferenceBooks
                .Include(r => r.Catalog)
                .Include(r => r.Libraian)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (referenceBook == null)
            {
                return NotFound();
            }

            return View(referenceBook);
        }

        // POST: ReferenceBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var referenceBook = await _context.ReferenceBooks.FindAsync(id);
            _context.ReferenceBooks.Remove(referenceBook);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReferenceBookExists(int id)
        {
            return _context.ReferenceBooks.Any(e => e.Id == id);
        }

        private bool valuesExists(string par1, string par2, int? id)
        {
            bool values = _context.ReferenceBooks.Any(
                referenceBook => referenceBook.Authorname == par1 && referenceBook.Bookname == par2 && referenceBook.Id != id);
            return values;
        }
    }
}
