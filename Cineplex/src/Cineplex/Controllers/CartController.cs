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
    public class CartController : Controller
    {
        private readonly CineplexContext _context;

        public CartController(CineplexContext context)
        {
            _context = context;    
        }

        // GET: Cart
        public async Task<IActionResult> Index()
        {
            var cineplexContext = _context.Booking.Include(b => b.Session);
            return View(await cineplexContext.ToListAsync());
        }

        
    }
}
