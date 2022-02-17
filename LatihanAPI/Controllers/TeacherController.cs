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
    public class TeacherController : ControllerBase
    {
        private readonly LatihanDBContext _context;

        public TeacherController(LatihanDBContext context)
        {
            _context = context;
        }

        // GET: api/Teacher
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mteacher>>> GetMteachers()
        {
            return await _context.Mteachers.ToListAsync();
        }

        // GET: api/Teacher/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mteacher>> GetMteacher(int id)
        {
            var mteacher = await _context.Mteachers.FindAsync(id);

            if (mteacher == null)
            {
                return NotFound();
            }

            return mteacher;
        }

        // PUT: api/Teacher/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMteacher(int id, Mteacher mteacher)
        {
            if (id != mteacher.TeacherId)
            {
                return BadRequest();
            }

            _context.Entry(mteacher).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MteacherExists(id))
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

        // POST: api/Teacher
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Mteacher>> PostMteacher(Mteacher mteacher)
        {
            _context.Mteachers.Add(mteacher);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMteacher", new { id = mteacher.TeacherId }, mteacher);
        }

        // DELETE: api/Teacher/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMteacher(int id)
        {
            var mteacher = await _context.Mteachers.FindAsync(id);
            if (mteacher == null)
            {
                return NotFound();
            }

            _context.Mteachers.Remove(mteacher);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MteacherExists(int id)
        {
            return _context.Mteachers.Any(e => e.TeacherId == id);
        }
    }
}
