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
    public class CinemasController : Controller
    {
        private readonly CineplexContext _context;

        public CinemasController(CineplexContext context)
        {
            _context = context;    
        }

        // GET: Cinemas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cinema.ToListAsync());
        }

    }
}
