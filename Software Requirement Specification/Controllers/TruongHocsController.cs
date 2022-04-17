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
    public class TruongHocsController : Controller
    {
        private readonly Software_Requirement_SpecificationContext _context;

        public TruongHocsController(Software_Requirement_SpecificationContext context)
        {
            _context = context;
        }

        // GET: TruongHocs
        public async Task<IActionResult> Index()
        {
            return View(await _context.TruongHoc.ToListAsync());
        }

        // GET: TruongHocs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var truongHoc = await _context.TruongHoc
                .FirstOrDefaultAsync(m => m.Id == id);
            if (truongHoc == null)
            {
                return NotFound();
            }

            return View(truongHoc);
        }

        // GET: TruongHocs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TruongHocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TenTruong,HieuTruong,LoaiTruong,WebSite,SoDienThoai,Email,TrangThai")] TruongHoc truongHoc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(truongHoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(truongHoc);
        }

        // GET: TruongHocs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var truongHoc = await _context.TruongHoc.FindAsync(id);
            if (truongHoc == null)
            {
                return NotFound();
            }
            return View(truongHoc);
        }

        // POST: TruongHocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TenTruong,HieuTruong,LoaiTruong,WebSite,SoDienThoai,Email,TrangThai")] TruongHoc truongHoc)
        {
            if (id != truongHoc.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(truongHoc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TruongHocExists(truongHoc.Id))
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
            return View(truongHoc);
        }

        // GET: TruongHocs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var truongHoc = await _context.TruongHoc
                .FirstOrDefaultAsync(m => m.Id == id);
            if (truongHoc == null)
            {
                return NotFound();
            }

            return View(truongHoc);
        }

        // POST: TruongHocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var truongHoc = await _context.TruongHoc.FindAsync(id);
            _context.TruongHoc.Remove(truongHoc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TruongHocExists(int id)
        {
            return _context.TruongHoc.Any(e => e.Id == id);
        }
    }
}
