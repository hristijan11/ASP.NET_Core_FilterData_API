using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentMovies.Models;

namespace RentMovies.Controllers
{
    public class PopularMoviesController : Controller
    {
        private readonly TheMovieAppContext _context;

        public PopularMoviesController(TheMovieAppContext context)
        {
            _context = context;
        }

        // GET: PopularMovies
        public async Task<IActionResult> Index()
        {
            return View(await _context.PopularMovies.ToListAsync());
        }

        // GET: PopularMovies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var popularMovie = await _context.PopularMovies
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (popularMovie == null)
            {
                return NotFound();
            }

            return View(popularMovie);
        }

        // GET: PopularMovies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PopularMovies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieId,OriginalTitle,Popularity,VoteCount,VoteAverage,Title")] PopularMovie popularMovie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(popularMovie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(popularMovie);
        }

        // GET: PopularMovies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var popularMovie = await _context.PopularMovies.FindAsync(id);
            if (popularMovie == null)
            {
                return NotFound();
            }
            return View(popularMovie);
        }

        // POST: PopularMovies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovieId,OriginalTitle,Popularity,VoteCount,VoteAverage,Title")] PopularMovie popularMovie)
        {
            if (id != popularMovie.MovieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(popularMovie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PopularMovieExists(popularMovie.MovieId))
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
            return View(popularMovie);
        }

        // GET: PopularMovies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var popularMovie = await _context.PopularMovies
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (popularMovie == null)
            {
                return NotFound();
            }

            return View(popularMovie);
        }

        // POST: PopularMovies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var popularMovie = await _context.PopularMovies.FindAsync(id);
            _context.PopularMovies.Remove(popularMovie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PopularMovieExists(int id)
        {
            return _context.PopularMovies.Any(e => e.MovieId == id);
        }
    }
}
