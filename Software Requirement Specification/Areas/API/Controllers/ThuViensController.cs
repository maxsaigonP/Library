﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Software_Requirement_Specification.Data;
using Software_Requirement_Specification.Models;

namespace Software_Requirement_Specification.Areas.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ThuViensController : ControllerBase
    {
        private readonly Software_Requirement_SpecificationContext _context;

        public ThuViensController(Software_Requirement_SpecificationContext context)
        {
            _context = context;
        }

        // GET: api/ThuViens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ThuVien>>> ThuVien()
        {
            return await _context.ThuVien.ToListAsync();
        }

        // GET: api/ThuViens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ThuVien>> ThuVien(int id)
        {
            var thuVien = await _context.ThuVien.FindAsync(id);

            if (thuVien == null)
            {
                return NotFound();
            }

            return thuVien;
        }
        //[HttpGet("{id}")]
        //public async Task<IList<dynamic>> HeThongThuVien(int id)
        //{
        //    var a = await _context.ThuVien.FindAsync(id);
        //    var b = await _context.TruongHoc.FindAsync(a.TruongHocId);
        //    List<dynamic> result = new List<dynamic>();
        //    result.Add(a);
        //    result.Add(b);

        //    return a;
        //}

        // PUT: api/ThuViens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> SuaThuVien(int id, [FromBody] ThuVien thuVien)
        {
            if (id != thuVien.Id)
            {
                return BadRequest();
            }

            _context.Entry(thuVien).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThuVienExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ThuViens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ThuVien>> ThemThuVien([FromBody] ThuVien thuVien)
        {
            _context.ThuVien.Add(thuVien);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetThuVien", new { id = thuVien.Id }, thuVien);
        }

        // DELETE: api/ThuViens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> XoaThuVien(int id)
        {
            var thuVien = await _context.ThuVien.FindAsync(id);
            if (thuVien == null)
            {
                return NotFound();
            }

            _context.ThuVien.Remove(thuVien);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ThuVienExists(int id)
        {
            return _context.ThuVien.Any(e => e.Id == id);
        }
    }
}
