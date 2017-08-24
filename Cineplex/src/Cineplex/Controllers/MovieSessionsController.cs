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

        
    }
}
