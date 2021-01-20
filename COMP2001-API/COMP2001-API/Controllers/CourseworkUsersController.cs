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

        //Delete a user
        [HttpPost, ActionName("DeleteUser")]
        public IActionResult DeleteUser(DeleteUser deleteUser)
        {
            var rowsaffected = _context.Database.ExecuteSqlRaw("EXEC DeleteUser @UserID",
                new SqlParameter("@UserID", deleteUser.UserID.ToString()));

            ViewBag.Success = rowsaffected;

            return RedirectToAction(nameof(Index));
        }

        //Register a new user
        [HttpPost, ActionName("Register")]
        public IActionResult Register(Register register)
        {
            var rowsaffected = _context.Database.ExecuteSqlRaw("EXEC Register @UserFirstName, @UserLastName, @UserEmail, @UserPassword",
                new SqlParameter("@UserFirstName", register.UserFirstName.ToString()),
                new SqlParameter("@UserLastName", register.UserLastName.ToString()),
                new SqlParameter("@UserEmail", register.UserEmail.ToString()),
                new SqlParameter("@UserPassword", register.UserPassword.ToString())
                );

            ViewBag.Success = rowsaffected;

            return RedirectToAction(nameof(Index));
        }

        //Update a user record
        [HttpPost, ActionName("UpdateUser")]
        public IActionResult UpdateUser(UpdateUser updateUser)
        {
            var rowsaffected = _context.Database.ExecuteSqlRaw("EXEC UpdateUser @UserFirstName, @UserLastName, @UserEmail, @UserPassword, @UserID",
                new SqlParameter("@UserFirstName", updateUser.UserFirstName.ToString()),
                new SqlParameter("@UserLastName", updateUser.UserLastName.ToString()),
                new SqlParameter("@UserEmail", updateUser.UserEmail.ToString()),
                new SqlParameter("@UserPassword", updateUser.UserPassword.ToString()),
                new SqlParameter("@UserID", updateUser.UserID.ToString())
                );

            ViewBag.Success = rowsaffected;

            return RedirectToAction(nameof(Index));
        }

        //Validate a user
        [HttpPost, ActionName("ValidateUser")]
        public IActionResult ValidateUser(ValidateUser validateUser)
        {
            var rowsaffected = _context.Database.ExecuteSqlRaw("EXEC ValidateUser @UserEmail, @UserPassword",
                new SqlParameter("@UserEmail", validateUser.UserEmail.ToString()),
                new SqlParameter("@UserPassword", validateUser.UserPassword.ToString())
                );

            ViewBag.Success = rowsaffected;

            return RedirectToAction(nameof(Index));
        }
    }
}
