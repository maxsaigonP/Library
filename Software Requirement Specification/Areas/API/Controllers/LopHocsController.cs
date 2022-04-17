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
    public class LopHocsController : ControllerBase
    {
        private readonly Software_Requirement_SpecificationContext _context;

        public LopHocsController(Software_Requirement_SpecificationContext context)
        {
            _context = context;
        }

        // GET: api/LopHocs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LopHoc>>> LopHoc()
        {
            return await _context.LopHoc.ToListAsync();
        }

        // GET: api/LopHocs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LopHoc>> LopHoc(int id)
        {
            var lopHoc = await _context.LopHoc.FindAsync(id);

            if (lopHoc == null)
            {
                return NotFound();
            }

            return lopHoc;
        }

        // PUT: api/LopHocs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> SuaLopHoc(int id,[FromBody] LopHoc lopHoc)
        {
            if (id != lopHoc.Id)
            {
                return BadRequest();
            }

            _context.Entry(lopHoc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LopHocExists(id))
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

        // POST: api/LopHocs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LopHoc>> ThemLopHoc([FromBody] LopHoc lopHoc)
        {
            _context.LopHoc.Add(lopHoc);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLopHoc", new { id = lopHoc.Id }, lopHoc);
        }

        // DELETE: api/LopHocs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> XoaLopHoc(int id)
        {
            var lopHoc = await _context.LopHoc.FindAsync(id);
            if (lopHoc == null)
            {
                return NotFound();
            }

            _context.LopHoc.Remove(lopHoc);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LopHocExists(int id)
        {
            return _context.LopHoc.Any(e => e.Id == id);
        }
    }
}
