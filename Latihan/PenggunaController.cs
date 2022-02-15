using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using latihan.vscode.web.Models;

namespace latihan.vscode.web
{
    public class PenggunaController : Controller
    {
        private readonly latihanContext _context;

        public PenggunaController(latihanContext context)
        {
            _context = context;
        }

        // GET: Pengguna
        public async Task<IActionResult> Index()
        {
            return View(await _context.MUser.ToListAsync());
        }

        // GET: Pengguna/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mUser = await _context.MUser
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (mUser == null)
            {
                return NotFound();
            }

            return View(mUser);
        }

        // GET: Pengguna/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pengguna/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,Name,Address")] MUser mUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mUser);
        }

        // GET: Pengguna/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mUser = await _context.MUser.FindAsync(id);
            if (mUser == null)
            {
                return NotFound();
            }
            return View(mUser);
        }

        // POST: Pengguna/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,Name,Address")] MUser mUser)
        {
            if (id != mUser.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MUserExists(mUser.UserId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(mUser);
        }

        // GET: Pengguna/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mUser = await _context.MUser
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (mUser == null)
            {
                return NotFound();
            }

            return View(mUser);
        }

        // POST: Pengguna/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mUser = await _context.MUser.FindAsync(id);
            _context.MUser.Remove(mUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MUserExists(int id)
        {
            return _context.MUser.Any(e => e.UserId == id);
        }
    }
}
