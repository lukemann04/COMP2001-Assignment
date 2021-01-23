using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
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

        // GET: CourseworkUsers/Validate/5
        public async Task<IActionResult> Validate(int? id)
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

        private bool CourseworkUserExists(int id)
        {
            return _context.CourseworkUsers.Any(e => e.UserId == id);
        }

        // POST: CourseworkUsers/Delete/5
        [HttpPost, ActionName("DeleteUser")]
        public IActionResult DeleteUser(DeleteUser deleteUser)
        {
            DataAccess dataAccess = new DataAccess(_context);
            dataAccess.DeleteUser(deleteUser);

            return RedirectToAction(nameof(Index));
        }

        // POST: CourseworkUsers/Create
        [HttpPost, ActionName("Register")]
        public IActionResult Register(Register register)
        {
            DataAccess dataAccess = new DataAccess(_context);
            dataAccess.Register(register);

            return RedirectToAction(nameof(Index));
        }

        // POST: CourseworkUsers/Edit/5
        [HttpPost, ActionName("UpdateUser")]
        public IActionResult UpdateUser(UpdateUser updateUser)
        {
            DataAccess dataAccess = new DataAccess(_context);
            dataAccess.UpdateUser(updateUser);

            return RedirectToAction(nameof(Index));
        }

        // POST: CourseworkUsers/Validate/5
        [HttpPost, ActionName("ValidateUser")]
        public IActionResult ValidateUser(ValidateUser validateUser)
        {
            DataAccess dataAccess = new DataAccess(_context);
            dataAccess.ValidateUser(validateUser);

            return RedirectToAction(nameof(Index));
        }
    }
}
