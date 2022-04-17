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
    public class PhanQuyensController : ControllerBase
    {
        private readonly Software_Requirement_SpecificationContext _context;

        public PhanQuyensController(Software_Requirement_SpecificationContext context)
        {
            _context = context;
        }

        // GET: api/PhanQuyens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhanQuyen>>> PhanQuyen()
        {
            return await _context.PhanQuyen.ToListAsync();
        }

        // GET: api/PhanQuyens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhanQuyen>> PhanQuyen(int id)
        {
            var phanQuyen = await _context.PhanQuyen.FindAsync(id);

            if (phanQuyen == null)
            {
                return NotFound();
            }

            return phanQuyen;
        }

        // PUT: api/PhanQuyens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> SuaPhanQuyen(int id, [FromBody] PhanQuyen phanQuyen)
        {
            if (id != phanQuyen.Id)
            {
                return BadRequest();
            }

            _context.Entry(phanQuyen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhanQuyenExists(id))
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

        // POST: api/PhanQuyens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PhanQuyen>> ThemPhanQuyen([FromBody] PhanQuyen phanQuyen)
        {
            _context.PhanQuyen.Add(phanQuyen);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPhanQuyen", new { id = phanQuyen.Id }, phanQuyen);
        }

        // DELETE: api/PhanQuyens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> XoaPhanQuyen(int id)
        {
            var phanQuyen = await _context.PhanQuyen.FindAsync(id);
            if (phanQuyen == null)
            {
                return NotFound();
            }

            _context.PhanQuyen.Remove(phanQuyen);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PhanQuyenExists(int id)
        {
            return _context.PhanQuyen.Any(e => e.Id == id);
        }
    }
}
