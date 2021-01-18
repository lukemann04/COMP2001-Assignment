using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using COMP2001_API.Models;

namespace COMP2001_API.Controllers
{
    public class CourseworkUsersController : Controller
    {
        private readonly COMP2001_LMannContext _context;

        public CourseworkUsersController(COMP2001_LMannContext context)
        {
            _context = context;
        }

        // GET: CourseworkUsers
        public async Task<IActionResult> Index()
        {
            return View(await _context.CourseworkUsers.ToListAsync());
        }

        // GET: CourseworkUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseworkUser = await _context.CourseworkUsers
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (courseworkUser == null)
            {
                return NotFound();
            }

            return View(courseworkUser);
        }

        // GET: CourseworkUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CourseworkUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,UserFirstName,UserLastName,UserEmail,UserPassword")] CourseworkUser courseworkUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(courseworkUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(courseworkUser);
        }

        // GET: CourseworkUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseworkUser = await _context.CourseworkUsers.FindAsync(id);
            if (courseworkUser == null)
            {
                return NotFound();
            }
            return View(courseworkUser);
        }

        // POST: CourseworkUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,UserFirstName,UserLastName,UserEmail,UserPassword")] CourseworkUser courseworkUser)
        {
            if (id != courseworkUser.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courseworkUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseworkUserExists(courseworkUser.UserId))
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
            return View(courseworkUser);
        }

        // GET: CourseworkUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseworkUser = await _context.CourseworkUsers
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (courseworkUser == null)
            {
                return NotFound();
            }

            return View(courseworkUser);
        }

        // POST: CourseworkUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var courseworkUser = await _context.CourseworkUsers.FindAsync(id);
            _context.CourseworkUsers.Remove(courseworkUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseworkUserExists(int id)
        {
            return _context.CourseworkUsers.Any(e => e.UserId == id);
        }
    }
}
