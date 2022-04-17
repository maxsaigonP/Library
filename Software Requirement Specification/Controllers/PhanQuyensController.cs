using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Software_Requirement_Specification.Data;
using Software_Requirement_Specification.Models;

namespace Software_Requirement_Specification.Controllers
{
    public class PhanQuyensController : Controller
    {
        private readonly Software_Requirement_SpecificationContext _context;

        public PhanQuyensController(Software_Requirement_SpecificationContext context)
        {
            _context = context;
        }

        // GET: PhanQuyens
        public async Task<IActionResult> Index()
        {
            return View(await _context.PhanQuyen.ToListAsync());
        }

        // GET: PhanQuyens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phanQuyen = await _context.PhanQuyen
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phanQuyen == null)
            {
                return NotFound();
            }

            return View(phanQuyen);
        }

        // GET: PhanQuyens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PhanQuyens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TenPhanQuyen")] PhanQuyen phanQuyen)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phanQuyen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(phanQuyen);
        }

        // GET: PhanQuyens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phanQuyen = await _context.PhanQuyen.FindAsync(id);
            if (phanQuyen == null)
            {
                return NotFound();
            }
            return View(phanQuyen);
        }

        // POST: PhanQuyens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TenPhanQuyen")] PhanQuyen phanQuyen)
        {
            if (id != phanQuyen.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phanQuyen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhanQuyenExists(phanQuyen.Id))
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
            return View(phanQuyen);
        }

        // GET: PhanQuyens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phanQuyen = await _context.PhanQuyen
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phanQuyen == null)
            {
                return NotFound();
            }

            return View(phanQuyen);
        }

        // POST: PhanQuyens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phanQuyen = await _context.PhanQuyen.FindAsync(id);
            _context.PhanQuyen.Remove(phanQuyen);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhanQuyenExists(int id)
        {
            return _context.PhanQuyen.Any(e => e.Id == id);
        }
    }
}
