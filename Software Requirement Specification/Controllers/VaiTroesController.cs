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
    public class VaiTroesController : Controller
    {
        private readonly Software_Requirement_SpecificationContext _context;

        public VaiTroesController(Software_Requirement_SpecificationContext context)
        {
            _context = context;
        }

        // GET: VaiTroes
        public async Task<IActionResult> Index()
        {
            var software_Requirement_SpecificationContext = _context.VaiTro.Include(v => v.PhanQuyen);
            return View(await software_Requirement_SpecificationContext.ToListAsync());
        }

        // GET: VaiTroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaiTro = await _context.VaiTro
                .Include(v => v.PhanQuyen)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vaiTro == null)
            {
                return NotFound();
            }

            return View(vaiTro);
        }

        // GET: VaiTroes/Create
        public IActionResult Create()
        {
            ViewData["PhanQuyenId"] = new SelectList(_context.PhanQuyen, "Id", "Id");
            return View();
        }

        // POST: VaiTroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TenVaiTro,MoTa,DeThiId,MonHoc,TepRiengTu,TaiNguyen,ThongBao,PhanQuyenId")] VaiTro vaiTro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vaiTro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PhanQuyenId"] = new SelectList(_context.PhanQuyen, "Id", "Id", vaiTro.PhanQuyenId);
            return View(vaiTro);
        }

        // GET: VaiTroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaiTro = await _context.VaiTro.FindAsync(id);
            if (vaiTro == null)
            {
                return NotFound();
            }
            ViewData["PhanQuyenId"] = new SelectList(_context.PhanQuyen, "Id", "Id", vaiTro.PhanQuyenId);
            return View(vaiTro);
        }

        // POST: VaiTroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TenVaiTro,MoTa,DeThiId,MonHoc,TepRiengTu,TaiNguyen,ThongBao,PhanQuyenId")] VaiTro vaiTro)
        {
            if (id != vaiTro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vaiTro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VaiTroExists(vaiTro.Id))
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
            ViewData["PhanQuyenId"] = new SelectList(_context.PhanQuyen, "Id", "Id", vaiTro.PhanQuyenId);
            return View(vaiTro);
        }

        // GET: VaiTroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaiTro = await _context.VaiTro
                .Include(v => v.PhanQuyen)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vaiTro == null)
            {
                return NotFound();
            }

            return View(vaiTro);
        }

        // POST: VaiTroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vaiTro = await _context.VaiTro.FindAsync(id);
            _context.VaiTro.Remove(vaiTro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VaiTroExists(int id)
        {
            return _context.VaiTro.Any(e => e.Id == id);
        }
    }
}
