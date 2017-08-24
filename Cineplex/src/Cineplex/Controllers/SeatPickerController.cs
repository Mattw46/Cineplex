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
    public class SeatPickerController : Controller
    {
        private readonly CineplexContext _context;

        public SeatPickerController(CineplexContext context)
        {
            _context = context;    
        }

        // GET: SeatPicker
        public async Task<IActionResult> Index(int? id)
        {
            ViewData["id"] = id;
            //var cineplexContext = _context.BookedSeats.Include(b => b.Session).Where(s.);
            var cineplexContext = _context.BookedSeats.Where(b => b.SessionId == id);
            return View(await cineplexContext.ToListAsync());
        }

        
    }
}
