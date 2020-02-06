using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SIKONSystem.Data;
using SIKONSystem.Models;

namespace SIKONSystem.Controllers
{
    public class BookingsController : Controller
    {
        private readonly MvcDbContext _context;

        public BookingsController(MvcDbContext context)
        {
            _context = context;
        }

        // GET: Bookings
        public async Task<IActionResult> Index()
        {
            var mvcDbContext = _context.Booking.Include(b => b.Lecture).Include(b => b.User);
            return View(await mvcDbContext.ToListAsync());
        }

        // GET: Bookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Booking
                .Include(b => b.Lecture)
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.BookingId == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // GET: Bookings/Create
        public IActionResult Create()
        {
            ViewData["LectureId"] = new SelectList(_context.Lecture, "LectureId", "Title");
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "Email");
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingId,UserId,LectureId")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                Lecture l = _context.Lecture.FindAsync(booking.LectureId).Result;
                if (l.Spaces < 1)
                {
                    booking.WaitList = true;
                    //WaitListsController wlCon = new WaitListsController(_context);
                    //WaitList wl = new WaitList(booking);
                    //wlCon.Create(wl);
                    //return RedirectToAction(nameof(Index));
                }

                _context.Add(booking);
                

                LecturesController con = new LecturesController(_context);
                foreach (var lecture in _context.Lecture)
                {
                    if (booking.LectureId == lecture.LectureId)
                    {
                        con.Edit(booking.LectureId, lecture);
                    }
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LectureId"] = new SelectList(_context.Lecture, "LectureId", "Title", booking.LectureId);
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "Email", booking.UserId);
            return View(booking);
        }

        // GET: Bookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Booking.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            ViewData["LectureId"] = new SelectList(_context.Lecture, "LectureId", "Title", booking.LectureId);
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "Email", booking.UserId);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookingId,UserId,LectureId")] Booking booking)
        {
            if (id != booking.BookingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(booking.BookingId))
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
            ViewData["LectureId"] = new SelectList(_context.Lecture, "LectureId", "Title", booking.LectureId);
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "Email", booking.UserId);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Booking
                .Include(b => b.Lecture)
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.BookingId == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var booking = await _context.Booking.FindAsync(id);
            int delLecture = booking.LectureId;
            _context.Booking.Remove(booking);
            bool waitListFound = false;

            foreach (var booking1 in _context.Booking)
            {
                if (booking1.LectureId == delLecture && booking1.WaitList == true)
                {
                    booking1.WaitList = false;
                    Edit(booking1.BookingId, booking1);
                    waitListFound = true;
                    break;
                }
            }

            if (waitListFound == false)
            {
                LecturesController con = new LecturesController(_context);
                con.Edit(delLecture, _context.Lecture.FindAsync(delLecture).Result);
            }

            /*await */_context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingExists(int id)
        {
            return _context.Booking.Any(e => e.BookingId == id);
        }
    }
}
