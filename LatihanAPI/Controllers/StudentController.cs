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
    public class StudentController : ControllerBase
    {
        private readonly LatihanDBContext _context;

        public StudentController(LatihanDBContext context)
        {
            _context = context;
        }

        // GET: api/Student
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mstudent>>> GetMstudents()
        {
            return await _context.Mstudents.ToListAsync();
        }

        // GET: api/Student/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mstudent>> GetMstudent(int id)
        {
            var mstudent = await _context.Mstudents.FindAsync(id);

            if (mstudent == null)
            {
                return NotFound();
            }

            return mstudent;
        }

        // PUT: api/Student/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMstudent(int id, Mstudent mstudent)
        {
            if (id != mstudent.StudentId)
            {
                return BadRequest();
            }

            _context.Entry(mstudent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MstudentExists(id))
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

        // POST: api/Student
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Mstudent>> PostMstudent(Mstudent mstudent)
        {
            _context.Mstudents.Add(mstudent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMstudent", new { id = mstudent.StudentId }, mstudent);
        }

        // DELETE: api/Student/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMstudent(int id)
        {
            var mstudent = await _context.Mstudents.FindAsync(id);
            if (mstudent == null)
            {
                return NotFound();
            }

            _context.Mstudents.Remove(mstudent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MstudentExists(int id)
        {
            return _context.Mstudents.Any(e => e.StudentId == id);
        }
    }
}
