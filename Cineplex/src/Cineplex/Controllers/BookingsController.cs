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
    public class BookingsController : Controller
    {
        private readonly CineplexContext _context;

        public BookingsController(CineplexContext context)
        {
            _context = context;    
        }

        // GET: Bookings
        public async Task<IActionResult> Index(int? id)
        {
            //var cineplexContext = _context.Booking.Include(b => b.Session);
            //return View(await cineplexContext.ToListAsync());
            var seats = await _context.BookedSeats.SingleOrDefaultAsync(m => m.SessionId == id);
            return View(seats);
        }

        
    }
}
