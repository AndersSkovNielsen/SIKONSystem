using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SIKONSystem.Data;
using SIKONSystem.Models;

namespace SIKONSystem.Controllers
{
    public class EventsOldController : Controller
    {
        private readonly MVCLectureContext _context;

        public EventsOldController(MVCLectureContext context)
        {
            _context = context;
        }



        Lecture l1 = new Lecture("Autisme og dig", 2, new Room(30,"C.20.06"), new Collection<User>(), "Tony Attwood", new Queue<User>());

        private Lecture _selectedLecture;
        public Lecture SelectedLecture
        {
            get => _selectedLecture;
            set => _selectedLecture = value;
        }

        [HttpGet]
        public IActionResult Index()
        {
            _selectedLecture = l1;
            BookingSingleton.Instance();
            return View();
        }
        
   
        public IActionResult Partake()
        { 
            BookingSingleton.Instance().Partake(l1, new User());
            //return false;
            return RedirectToAction("Index");

        }

        public static bool Cancel()
        {
            return false;
        }
    }
}