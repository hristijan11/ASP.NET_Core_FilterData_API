using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentMovies.Models;
using RentMovies.UserRegistration;

namespace RentMovies.Controllers
{
    public class UserRegsController : Controller
    {
        private readonly TheMovieAppContext _theMovieAppContext;
        public UserRegsController(TheMovieAppContext theMovieAppContext)
        {
            _theMovieAppContext = theMovieAppContext;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UserReg userReg)
        {
            _theMovieAppContext.Add(userReg);
            _theMovieAppContext.SaveChanges();
            ViewBag.message = "User is " + userReg + " succesfully added!";
            return View();
        }

    }
}
//        private readonly TheMovieAppContext _context;

//        public UserRegsController(TheMovieAppContext context)
//        {
//            _context = context;
//        }

//        // GET: UserRegs
//        public async Task<IActionResult> Index()
//        {
//            return View(await _context.UserRegs.ToListAsync());
//        }

//        // GET: UserRegs/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var userReg = await _context.UserRegs
//                .FirstOrDefaultAsync(m => m.UserId == id);
//            if (userReg == null)
//            {
//                return NotFound();
//            }

//            return View(userReg);
//        }

//        // GET: UserRegs/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: UserRegs/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("UserId,Username,Password,ConfirmPassword,UserEmail,MartialStatus")] UserReg userReg)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(userReg);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(userReg);
//        }

//        // GET: UserRegs/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var userReg = await _context.UserRegs.FindAsync(id);
//            if (userReg == null)
//            {
//                return NotFound();
//            }
//            return View(userReg);
//        }

//        // POST: UserRegs/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("UserId,Username,Password,ConfirmPassword,UserEmail,MartialStatus")] UserReg userReg)
//        {
//            if (id != userReg.UserId)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(userReg);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!UserRegExists(userReg.UserId))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(userReg);
//        }

//        // GET: UserRegs/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var userReg = await _context.UserRegs
//                .FirstOrDefaultAsync(m => m.UserId == id);
//            if (userReg == null)
//            {
//                return NotFound();
//            }

//            return View(userReg);
//        }

//        // POST: UserRegs/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var userReg = await _context.UserRegs.FindAsync(id);
//            _context.UserRegs.Remove(userReg);
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool UserRegExists(int id)
//        {
//            return _context.UserRegs.Any(e => e.UserId == id);
//        }
//    }
//}
