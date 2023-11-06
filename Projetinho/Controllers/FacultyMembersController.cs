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
    public class FacultyMembersController : Controller
    {
        private readonly MyDbContext _context;

        public FacultyMembersController(MyDbContext context)
        {
            _context = context;
        }

        // GET: FacultyMembers
        public async Task<IActionResult> Index()
        {
            return View(await _context.FacultyMembers.ToListAsync());
        }

        // GET: FacultyMembers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facultyMember = await _context.FacultyMembers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (facultyMember == null)
            {
                return NotFound();
            }

            return View(facultyMember);
        }

        // GET: FacultyMembers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FacultyMembers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Facultycoll,Id,Name,Address,Contact")] FacultyMember facultyMember)
        {
            if (ModelState.IsValid)
            {
                if (valuesExists(facultyMember.Name, facultyMember.Contact, null))
                {
                    ModelState.AddModelError("Name", "Combinação de nome e contato já existente.");
                    return View(facultyMember);
                }

                _context.Add(facultyMember);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(facultyMember);
        }

        // GET: FacultyMembers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facultyMember = await _context.FacultyMembers.FindAsync(id);
            if (facultyMember == null)
            {
                return NotFound();
            }
            return View(facultyMember);
        }

        // POST: FacultyMembers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Facultycoll,Id,Name,Address,Contact")] FacultyMember facultyMember)
        {
            if (id != facultyMember.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (valuesExists(facultyMember.Name, facultyMember.Contact, id))
                {
                    ModelState.AddModelError("Name", "Combinação de nome e contato já existente.");
                    return View(facultyMember);
                }

                try
                {
                    _context.Update(facultyMember);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacultyMemberExists(facultyMember.Id))
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
            return View(facultyMember);
        }

        // GET: FacultyMembers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facultyMember = await _context.FacultyMembers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (facultyMember == null)
            {
                return NotFound();
            }

            return View(facultyMember);
        }

        // POST: FacultyMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var facultyMember = await _context.FacultyMembers.FindAsync(id);
            _context.FacultyMembers.Remove(facultyMember);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacultyMemberExists(int id)
        {
            return _context.FacultyMembers.Any(e => e.Id == id);
        }

        private bool valuesExists(string name, int contact, int? id)
        {
            bool values = _context.FacultyMembers.Any(
                facultyMember => facultyMember.Name == name && facultyMember.Contact == contact && facultyMember.Id != id);
            return values;
        }
    }
}
