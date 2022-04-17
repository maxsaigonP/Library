using System;
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
    public class TruongHocsController : ControllerBase
    {
        private readonly Software_Requirement_SpecificationContext _context;

        public TruongHocsController(Software_Requirement_SpecificationContext context)
        {
            _context = context;
        }

        // GET: api/TruongHocs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TruongHoc>>> TruongHoc()
        {
            return await _context.TruongHoc.ToListAsync();
        }

        // GET: api/TruongHocs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TruongHoc>> TruongHoc(int id)
        {
            var truongHoc = await _context.TruongHoc.FindAsync(id);

            if (truongHoc == null)
            {
                return NotFound();
            }

            return truongHoc;
        }

        // PUT: api/TruongHocs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> SuaTruongHoc(int id,[FromBody] TruongHoc truongHoc)
        {
            if (id != truongHoc.Id)
            {
                return BadRequest();
            }

            _context.Entry(truongHoc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TruongHocExists(id))
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

        // POST: api/TruongHocs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TruongHoc>> ThemTruongHoc([FromBody] TruongHoc truongHoc)
        {
            _context.TruongHoc.Add(truongHoc);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTruongHoc", new { id = truongHoc.Id }, truongHoc);
        }

        // DELETE: api/TruongHocs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> XoaTruongHoc(int id)
        {
            var truongHoc = await _context.TruongHoc.FindAsync(id);
            if (truongHoc == null)
            {
                return NotFound();
            }

            _context.TruongHoc.Remove(truongHoc);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TruongHocExists(int id)
        {
            return _context.TruongHoc.Any(e => e.Id == id);
        }
    }
}
