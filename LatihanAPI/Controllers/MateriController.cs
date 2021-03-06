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
        public async Task<ActionResult<IEnumerable<Mmateri>>> GetMmateris()
        {
            return await _context.Mmateris.ToListAsync();
        }

        // GET: api/Materi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mmateri>> GetMmateri(int id)
        {
            var mmateri = await _context.Mmateris.FindAsync(id);

            if (mmateri == null)
            {
                return NotFound();
            }

            return mmateri;
        }

        // PUT: api/Materi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMmateri(int id, Mmateri mmateri)
        {
            if (id != mmateri.MateriId)
            {
                return BadRequest();
            }

            _context.Entry(mmateri).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MmateriExists(id))
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
        public async Task<ActionResult<Mmateri>> PostMmateri(Mmateri mmateri)
        {
            _context.Mmateris.Add(mmateri);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMmateri", new { id = mmateri.MateriId }, mmateri);
        }

        // DELETE: api/Materi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMmateri(int id)
        {
            var mmateri = await _context.Mmateris.FindAsync(id);
            if (mmateri == null)
            {
                return NotFound();
            }

            _context.Mmateris.Remove(mmateri);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MmateriExists(int id)
        {
            return _context.Mmateris.Any(e => e.MateriId == id);
        }
    }
}
