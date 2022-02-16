using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LatihanAPI.Data;
using LatihanAPI.Models;

namespace LatihanAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriController : ControllerBase
    {
        private readonly LatihanDBContext _context;

        public MateriController(LatihanDBContext context)
        {
            _context = context;
        }

        // GET: api/Materi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MMateri>>> GetMMateris()
        {
            return await _context.MMateris.ToListAsync();
        }

        // GET: api/Materi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MMateri>> GetMMateri(int id)
        {
            var mMateri = await _context.MMateris.FindAsync(id);

            if (mMateri == null)
            {
                return NotFound();
            }

            return mMateri;
        }

        // PUT: api/Materi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMMateri(int id, MMateri mMateri)
        {
            if (id != mMateri.MateriId)
            {
                return BadRequest();
            }

            _context.Entry(mMateri).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MMateriExists(id))
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

        // POST: api/Materi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MMateri>> PostMMateri(MMateri mMateri)
        {
            _context.MMateris.Add(mMateri);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMMateri", new { id = mMateri.MateriId }, mMateri);
        }

        // DELETE: api/Materi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMMateri(int id)
        {
            var mMateri = await _context.MMateris.FindAsync(id);
            if (mMateri == null)
            {
                return NotFound();
            }

            _context.MMateris.Remove(mMateri);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MMateriExists(int id)
        {
            return _context.MMateris.Any(e => e.MateriId == id);
        }
    }
}
