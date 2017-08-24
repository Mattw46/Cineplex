using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cineplex.Models;
using Microsoft.AspNetCore.Http;

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
        public async Task<IActionResult> Index(string cinemaString, string movieString, int sessionID)
        {
            /* I encountered an issue here where I could not declare var session up front
               without assigning a result set. this meant that session was out of scope
               when returning at the end of the method. i had no choice but to duplicate the
               return statement inside each if statement */

            if (sessionID != null)
            {
                string i = sessionID.ToString();
                HttpContext.Session.SetInt32(i, 1);
                ViewData["SessionId"] = sessionID;
            }
            
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

        /* testing */
        //[HttpPost]
        //public IActionResult Index(int movie)
        //{
            
        //}
    }
}

//var movieAct = MovieManager.Instance.Movies.First(m => m.ID == movie);
//HttpContext.Session.SetString("SessionId", "test title");
            //HttpContext.Session.SetInt32("MovieId", 1);
            //["MovieId"] = 1;
            //ViewData["SessionId"] = 2;
            //return RedirectToAction("Index", "MovieSessions");
//return View();