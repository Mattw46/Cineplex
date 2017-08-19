using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cineplex.Models;

namespace Cineplex.Controllers
{
    public class MovieSessionsController : Controller
    {
        private readonly CineplexContext _context;

        public MovieSessionsController(CineplexContext context)
        {
            _context = context;    
        }

        // GET: MovieSessions filtered
        public async Task<IActionResult> Index(string cinemaString, string movieString)
        {
            /* I encountered an issue here where I could not declare var session up front
               without assigning a result set. this meant that session was out of scope
               when returning at the end of the method. i had no choice but to duplicate the
               return statement inside each if statement */
            
            if (!String.IsNullOrEmpty(cinemaString) && String.IsNullOrEmpty(movieString))
            {
                var sessions = _context.Session.Include(s => s.Cinema)
                    .Include(s => s.Movie).AsNoTracking()
                    .Where(s => s.Cinema.Location.Contains(cinemaString));
                return View(await sessions.ToListAsync());
            }
            else if (String.IsNullOrEmpty(cinemaString) && !String.IsNullOrEmpty(movieString))
            {
                var sessions = _context.Session.Include(s => s.Cinema)
                    .Include(s => s.Movie).AsNoTracking()
                    .Where(s => s.Movie.Title.Contains(movieString));
                return View(await sessions.ToListAsync());
            }
            else if (!String.IsNullOrEmpty(cinemaString) && !String.IsNullOrEmpty(movieString))
            {
                var sessions = _context.Session.Include(s => s.Cinema)
                    .Include(s => s.Movie)
                    .Where(s => s.Cinema.Location.Contains(cinemaString))
                    .Where(s => s.Movie.Title.Contains(movieString)).AsNoTracking();
                return View(await sessions.ToListAsync());
            }
            else
            {
                var sessions = _context.Session.Include(s => s.Cinema)
                    .Include(s => s.Movie).AsNoTracking();
                return View(await sessions.ToListAsync());
            }
            
            
        }

        // GET: MovieSessions/Details/5
        /*public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var session = await _context.Session.SingleOrDefaultAsync(m => m.SessionId == id);
            if (session == null)
            {
                return NotFound();
            }

            return View(session);
        }

        // GET: MovieSessions/Create
        public IActionResult Create()
        {
            ViewData["CinemaId"] = new SelectList(_context.Cinema, "CinemaId", "Location");
            ViewData["MovieId"] = new SelectList(_context.Movie, "MovieId", "LongDescription");
            return View();
        }

        // POST: MovieSessions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SessionId,CinemaId,MovieId,SessionDate")] Session session)
        {
            if (ModelState.IsValid)
            {
                _context.Add(session);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["CinemaId"] = new SelectList(_context.Cinema, "CinemaId", "Location", session.CinemaId);
            ViewData["MovieId"] = new SelectList(_context.Movie, "MovieId", "LongDescription", session.MovieId);
            return View(session);
        }

        // GET: MovieSessions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var session = await _context.Session.SingleOrDefaultAsync(m => m.SessionId == id);
            if (session == null)
            {
                return NotFound();
            }
            ViewData["CinemaId"] = new SelectList(_context.Cinema, "CinemaId", "Location", session.CinemaId);
            ViewData["MovieId"] = new SelectList(_context.Movie, "MovieId", "LongDescription", session.MovieId);
            return View(session);
        }

        // POST: MovieSessions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SessionId,CinemaId,MovieId,SessionDate")] Session session)
        {
            if (id != session.SessionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(session);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SessionExists(session.SessionId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["CinemaId"] = new SelectList(_context.Cinema, "CinemaId", "Location", session.CinemaId);
            ViewData["MovieId"] = new SelectList(_context.Movie, "MovieId", "LongDescription", session.MovieId);
            return View(session);
        }

        // GET: MovieSessions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var session = await _context.Session.SingleOrDefaultAsync(m => m.SessionId == id);
            if (session == null)
            {
                return NotFound();
            }

            return View(session);
        }

        // POST: MovieSessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var session = await _context.Session.SingleOrDefaultAsync(m => m.SessionId == id);
            _context.Session.Remove(session);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool SessionExists(int id)
        {
            return _context.Session.Any(e => e.SessionId == id);
        }*/
    }
}
