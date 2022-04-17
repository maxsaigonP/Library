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
    public class NguoiDungsController : ControllerBase
    {
        private readonly Software_Requirement_SpecificationContext _context;

        public NguoiDungsController(Software_Requirement_SpecificationContext context)
        {
            _context = context;
        }

        // GET: api/NguoiDungs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NguoiDung>>> NguoiDung()
        {
            return await _context.NguoiDung.ToListAsync();
        }

        // GET: api/NguoiDungs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NguoiDung>> NguoiDung(int id)
        {
            var nguoiDung = await _context.NguoiDung.FindAsync(id);

            if (nguoiDung == null)
            {
                return NotFound();
            }

            return nguoiDung;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<NguoiDung>>> LocNguoiDung(int id)
        {
            var result = await _context.NguoiDung.Where(v=>v.VaitroId==id).ToListAsync();
            return result;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NguoiDung>>> SearchNguoiDung(string content)
        {
            var result = await _context.NguoiDung.Where(n => n.Ten.Contains(content)).ToListAsync();
            return result;
        }

        // PUT: api/NguoiDungs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> SuaNguoiDung(int id,[FromBody] NguoiDung nguoiDung)
        {
            if (id != nguoiDung.Id)
            {
                return BadRequest();
            }

            _context.Entry(nguoiDung).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NguoiDungExists(id))
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

        // POST: api/NguoiDungs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NguoiDung>> ThemNguoiDung([FromBody] NguoiDung nguoiDung)
        {
            _context.NguoiDung.Add(nguoiDung);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNguoiDung", new { id = nguoiDung.Id }, nguoiDung);
        }

        // DELETE: api/NguoiDungs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> XoaNguoiDung(int id)
        {
            var nguoiDung = await _context.NguoiDung.FindAsync(id);
            if (nguoiDung == null)
            {
                return NotFound();
            }

            _context.NguoiDung.Remove(nguoiDung);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NguoiDungExists(int id)
        {
            return _context.NguoiDung.Any(e => e.Id == id);
        }
    }
}
