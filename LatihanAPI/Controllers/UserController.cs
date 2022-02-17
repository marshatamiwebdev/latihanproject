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
    public class UserController : ControllerBase
    {
        private readonly LatihanDBContext _context;

        public UserController(LatihanDBContext context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Muser>>> GetMusers()
        {
            return await _context.Musers.ToListAsync();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Muser>> GetMuser(int id)
        {
            var muser = await _context.Musers.FindAsync(id);

            if (muser == null)
            {
                return NotFound();
            }

            return muser;
        }

        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMuser(int id, Muser muser)
        {
            if (id != muser.UserId)
            {
                return BadRequest();
            }

            _context.Entry(muser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MuserExists(id))
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

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Muser>> PostMuser(Muser muser)
        {
            _context.Musers.Add(muser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMuser", new { id = muser.UserId }, muser);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMuser(int id)
        {
            var muser = await _context.Musers.FindAsync(id);
            if (muser == null)
            {
                return NotFound();
            }

            _context.Musers.Remove(muser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MuserExists(int id)
        {
            return _context.Musers.Any(e => e.UserId == id);
        }
    }
}
