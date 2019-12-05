using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using SIKONSystem.Data;
using SIKONSystem.DisplayModel;
using SIKONSystem.Models;

namespace SIKONSystem.Controllers
{
    public class EventsController : Controller
    {
        private readonly MVCLectureContext _context;
        private LectureDisplayModel Display = new LectureDisplayModel();



        public EventsController(MVCLectureContext context)
        {
            _context = context;
        }

        public IQueryable<string> RoomQuery() {  IQueryable<string> retRoom = from R in _context.Lecture
            select R.Room.Name;
            return retRoom;
        }

        public IQueryable<Room> GetRoomsQuery()
        {
            var rooms = from R in _context.Lecture
                select R.Room;
            
            return rooms;

        }



        // GET: Events
        public async Task<IActionResult> Index()
        {
            //IQueryable<int> dbLenght = from R in _context.Lecture
            //    select _context.Lecture.Count();
            var displaylist = from L in _context.Lecture
                select L;

            Display.LextureDisplayList = await displaylist.ToListAsync();
            BookingSingleton.Instance();
            return View(Display);
        }

        // GET: Events/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lecture = await _context.Lecture
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lecture == null)
            {
                return NotFound();
            }

            return View(lecture);
        }

        // GET: Events/Create
        public async Task<IActionResult> Create()
        {
            IQueryable<string> retRoom = from R in _context.Lecture
                select R.Room.Name;

            Display.Rooms = new SelectList(await RoomQuery().Distinct().ToListAsync());
                
            return View(Display);
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,TimeFrame,StartTime,Spaces,Description,Speaker")] Lecture lecture)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lecture);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lecture);
        }

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lecture = await _context.Lecture.FindAsync(id);
            if (lecture == null)
            {
                return NotFound();
            }
            return View(lecture);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,TimeFrame,StartTime,Spaces,Description,Speaker")] Lecture lecture)
        {
            if (id != lecture.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lecture);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LectureExists(lecture.Id))
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
            return View(lecture);
        }

        // GET: Events/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lecture = await _context.Lecture
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lecture == null)
            {
                return NotFound();
            }

            return View(lecture);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lecture = await _context.Lecture.FindAsync(id);
            _context.Lecture.Remove(lecture);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LectureExists(int id)
        {
            return _context.Lecture.Any(e => e.Id == id);
        }

        public async Task<IActionResult>  Partake(int? id)
        {
            BookingSingleton.Instance().Partake(await _context.Lecture.FindAsync(id), new User());
            //return false;
            return RedirectToAction("Index");

        }
    }
}
