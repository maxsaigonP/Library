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
    public class BaiGiangsController : ControllerBase
    {
        private readonly Software_Requirement_SpecificationContext _context;

        public BaiGiangsController(Software_Requirement_SpecificationContext context)
        {
            _context = context;
        }

        // GET: api/BaiGiangs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BaiGiang>>> BaiGiang()
        {
            return await _context.BaiGiang.ToListAsync();
        }

        // GET: api/BaiGiangs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BaiGiang>> BaiGiang(int id)
        {
            var baiGiang = await _context.BaiGiang.FindAsync(id);

            if (baiGiang == null)
            {
                return NotFound();
            }

            return baiGiang;
        }

        // PUT: api/BaiGiangs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> SuaBaiGiang(int id,[FromBody] BaiGiang baiGiang)
        {
            if (id != baiGiang.Id)
            {
                return BadRequest();
            }

            _context.Entry(baiGiang).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BaiGiangExists(id))
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

        // POST: api/BaiGiangs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BaiGiang>> ThemBaiGiang([FromBody] BaiGiang baiGiang)
        {
            _context.BaiGiang.Add(baiGiang);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBaiGiang", new { id = baiGiang.Id }, baiGiang);
        }

        // DELETE: api/BaiGiangs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> XoaBaiGiang(int id)
        {
            var baiGiang = await _context.BaiGiang.FindAsync(id);
            if (baiGiang == null)
            {
                return NotFound();
            }

            _context.BaiGiang.Remove(baiGiang);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BaiGiangExists(int id)
        {
            return _context.BaiGiang.Any(e => e.Id == id);
        }
    }
}
