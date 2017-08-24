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
    public class EnquiriesController : Controller
    {
        private readonly CineplexContext _context;

        public EnquiriesController(CineplexContext context)
        {
            _context = context;    
        }

    }
}
