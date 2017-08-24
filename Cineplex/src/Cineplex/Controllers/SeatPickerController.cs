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

        // GET: SeatPicker/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookedSeats = await _context.BookedSeats.SingleOrDefaultAsync(m => m.SessionId == id);
            if (bookedSeats == null)
            {
                return NotFound();
            }

            return View(bookedSeats);
        }

        // GET: SeatPicker/Create
        public IActionResult Create()
        {
            ViewData["SessionId"] = new SelectList(_context.Session, "SessionId", "SessionId");
            return View();
        }

        // POST: SeatPicker/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SessionId,SeatNumber")] BookedSeats bookedSeats)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookedSeats);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["SessionId"] = new SelectList(_context.Session, "SessionId", "SessionId", bookedSeats.SessionId);
            return View(bookedSeats);
        }

        // GET: SeatPicker/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookedSeats = await _context.BookedSeats.SingleOrDefaultAsync(m => m.SessionId == id);
            if (bookedSeats == null)
            {
                return NotFound();
            }
            ViewData["SessionId"] = new SelectList(_context.Session, "SessionId", "SessionId", bookedSeats.SessionId);
            return View(bookedSeats);
        }

        // POST: SeatPicker/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SessionId,SeatNumber")] BookedSeats bookedSeats)
        {
            if (id != bookedSeats.SessionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookedSeats);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookedSeatsExists(bookedSeats.SessionId))
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
            ViewData["SessionId"] = new SelectList(_context.Session, "SessionId", "SessionId", bookedSeats.SessionId);
            return View(bookedSeats);
        }

        // GET: SeatPicker/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookedSeats = await _context.BookedSeats.SingleOrDefaultAsync(m => m.SessionId == id);
            if (bookedSeats == null)
            {
                return NotFound();
            }

            return View(bookedSeats);
        }

        // POST: SeatPicker/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookedSeats = await _context.BookedSeats.SingleOrDefaultAsync(m => m.SessionId == id);
            _context.BookedSeats.Remove(bookedSeats);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool BookedSeatsExists(int id)
        {
            return _context.BookedSeats.Any(e => e.SessionId == id);
        }
    }
}
