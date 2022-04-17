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
    public class DeThisController : ControllerBase
    {
        private readonly Software_Requirement_SpecificationContext _context;

        public DeThisController(Software_Requirement_SpecificationContext context)
        {
            _context = context;
        }

        // GET: api/DeThis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeThi>>> DeThi()
        {
            return await _context.DeThi.ToListAsync();
        }

        // GET: api/DeThis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeThi>> DeThi(int id)
        {
            var deThi = await _context.DeThi.FindAsync(id);

            if (deThi == null)
            {
                return NotFound();
            }

            return deThi;
        }

        // PUT: api/DeThis/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> SuaDeThi(int id,[FromBody] DeThi deThi)
        {
            if (id != deThi.Id)
            {
                return BadRequest();
            }

            _context.Entry(deThi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeThiExists(id))
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

        // POST: api/DeThis
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DeThi>> ThemDeThi([FromBody] DeThi deThi)
        {
            _context.DeThi.Add(deThi);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeThi", new { id = deThi.Id }, deThi);
        }

        // DELETE: api/DeThis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> XoaDeThi(int id)
        {
            var deThi = await _context.DeThi.FindAsync(id);
            if (deThi == null)
            {
                return NotFound();
            }

            _context.DeThi.Remove(deThi);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeThiExists(int id)
        {
            return _context.DeThi.Any(e => e.Id == id);
        }
    }
}
