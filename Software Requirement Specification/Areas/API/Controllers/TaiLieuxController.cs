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
    public class TaiLieuxController : ControllerBase
    {
        private readonly Software_Requirement_SpecificationContext _context;

        public TaiLieuxController(Software_Requirement_SpecificationContext context)
        {
            _context = context;
        }

        // GET: api/TaiLieux
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaiLieu>>> TaiLieu()
        {
            return await _context.TaiLieu.ToListAsync();
        }

        // GET: api/TaiLieux/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaiLieu>> TaiLieu(int id)
        {
            var taiLieu = await _context.TaiLieu.FindAsync(id);

            if (taiLieu == null)
            {
                return NotFound();
            }

            return taiLieu;
        }
        //
    
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaiLieu>>> LocTaiLieu(int ?tt, int gv, int mh)
        {
           
            if(tt==null)
            {
                tt = 1;
            }

            var result = await _context.TaiLieu.ToListAsync();
            if (gv!=0&&mh!=0)
            {
                result = await _context.TaiLieu.Where(t => t.TinhTrang == (tt !=0) ? true : false).Where(t => t.NguoiDungId == gv&& t.MonHocId == mh).ToListAsync();
            }else
            if(mh!=0)
            {
                result = await _context.TaiLieu.Where(t => t.TinhTrang == (tt != 0) ? true : false).Where(t => t.MonHocId == mh).ToListAsync();
            }else
            if (gv != 0)
            {
                result = await _context.TaiLieu.Where(t => t.TinhTrang == (tt != 0) ? true : false).Where(t => t.NguoiDungId == gv).ToListAsync();
            }

            return result;
        }

        //

        public async Task<ActionResult<IEnumerable<TaiLieu>>> SearchTaiLieu(string content)
        {
            var taiLieu = await _context.TaiLieu.Where(m => m.MonHocI.TenMonHoc.Contains(content)).ToListAsync();

            if (taiLieu == null)
            {
                return NotFound();
            }

            return taiLieu;
        }

        // PUT: api/TaiLieux/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> SuaTaiLieu(int id,[FromBody] TaiLieu taiLieu)
        {
            if (id != taiLieu.Id)
            {
                return BadRequest();
            }

            _context.Entry(taiLieu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaiLieuExists(id))
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

        // POST: api/TaiLieux
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TaiLieu>> ThemTaiLieu([FromBody] TaiLieu taiLieu)
        {
            _context.TaiLieu.Add(taiLieu);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaiLieu", new { id = taiLieu.Id }, taiLieu);
        }

        // DELETE: api/TaiLieux/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> XoaTaiLieu(int id)
        {
            var taiLieu = await _context.TaiLieu.FindAsync(id);
            if (taiLieu == null)
            {
                return NotFound();
            }

            _context.TaiLieu.Remove(taiLieu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TaiLieuExists(int id)
        {
            return _context.TaiLieu.Any(e => e.Id == id);
        }
    }
}
