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
    public class VaiTroesController : ControllerBase
    {
        private readonly Software_Requirement_SpecificationContext _context;

        public VaiTroesController(Software_Requirement_SpecificationContext context)
        {
            _context = context;
        }

        // GET: api/VaiTroes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VaiTro>>> VaiTro()
        {
            return await _context.VaiTro.ToListAsync();
        }

        // GET: api/VaiTroes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VaiTro>> VaiTro(int id)
        {
            var vaiTro = await _context.VaiTro.FindAsync(id);

            if (vaiTro == null)
            {
                return NotFound();
            }

            return vaiTro;
        }

        // PUT: api/VaiTroes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> SuaVaiTro(int id, [FromBody] VaiTro vaiTro)
        {
            if (id != vaiTro.Id)
            {
                return BadRequest();
            }

            _context.Entry(vaiTro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VaiTroExists(id))
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

        // POST: api/VaiTroes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VaiTro>> ThemVaiTro([FromBody] VaiTro vaiTro)
        {
            _context.VaiTro.Add(vaiTro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVaiTro", new { id = vaiTro.Id }, vaiTro);
        }

        // DELETE: api/VaiTroes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> XoaVaiTro(int id)
        {
            var vaiTro = await _context.VaiTro.FindAsync(id);
            if (vaiTro == null)
            {
                return NotFound();
            }

            _context.VaiTro.Remove(vaiTro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VaiTroExists(int id)
        {
            return _context.VaiTro.Any(e => e.Id == id);
        }
    }
}
