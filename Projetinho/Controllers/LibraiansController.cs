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
    public class LibraiansController : Controller
    {
        private readonly MyDbContext _context;

        public LibraiansController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Libraians
        public async Task<IActionResult> Index()
        {
            return View(await _context.Libraians.ToListAsync());
        }

        // GET: Libraians/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libraian = await _context.Libraians
                .FirstOrDefaultAsync(m => m.Id == id);
            if (libraian == null)
            {
                return NotFound();
            }

            return View(libraian);
        }

        // GET: Libraians/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Libraians/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address,Mobileno")] Libraian libraian)
        {
            if (ModelState.IsValid)
            {
                if (valuesExists(libraian.Name, libraian.Address, null))
                {
                    ModelState.AddModelError("Name", "Combinação de nome e endereço já existente.");
                    return View(libraian);
                }

                _context.Add(libraian);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(libraian);
        }

        // GET: Libraians/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libraian = await _context.Libraians.FindAsync(id);
            if (libraian == null)
            {
                return NotFound();
            }
            return View(libraian);
        }

        // POST: Libraians/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address,Mobileno")] Libraian libraian)
        {
            if (id != libraian.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (valuesExists(libraian.Name, libraian.Address, id))
                {
                    ModelState.AddModelError("Name", "Combinação de nome e endereço já existente.");
                    return View(libraian);
                }

                try
                {
                    _context.Update(libraian);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibraianExists(libraian.Id))
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
            return View(libraian);
        }

        // GET: Libraians/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libraian = await _context.Libraians
                .FirstOrDefaultAsync(m => m.Id == id);
            if (libraian == null)
            {
                return NotFound();
            }

            return View(libraian);
        }

        // POST: Libraians/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var libraian = await _context.Libraians.FindAsync(id);
            _context.Libraians.Remove(libraian);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibraianExists(int id)
        {
            return _context.Libraians.Any(e => e.Id == id);
        }

        private bool valuesExists(string name, string address, int? id)
        {
            bool values = _context.Libraians.Any(
                libraian => libraian.Name == name && libraian.Address == address && libraian.Id != id);
            return values;
        }
    }
}
