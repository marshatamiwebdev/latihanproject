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
        public async Task<ActionResult<IEnumerable<MUser>>> GetMUsers()
        {
            return await _context.MUsers.ToListAsync();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MUser>> GetMUser(int id)
        {
            var mUser = await _context.MUsers.FindAsync(id);

            if (mUser == null)
            {
                return NotFound();
            }

            return mUser;
        }

        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMUser(int id, MUser mUser)
        {
            if (id != mUser.UserId)
            {
                return BadRequest();
            }

            _context.Entry(mUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MUserExists(id))
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
        public async Task<ActionResult<MUser>> PostMUser(MUser mUser)
        {
            _context.MUsers.Add(mUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMUser", new { id = mUser.UserId }, mUser);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMUser(int id)
        {
            var mUser = await _context.MUsers.FindAsync(id);
            if (mUser == null)
            {
                return NotFound();
            }

            _context.MUsers.Remove(mUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MUserExists(int id)
        {
            return _context.MUsers.Any(e => e.UserId == id);
        }
    }
}
