using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SIKONSystem.Models;

namespace SIKONSystem.Controllers
{
    public class EventsController : Controller
    {
        public IActionResult Index()
        {
            BookingSingleton.Instance();
            return View();
        }

   
        public IActionResult Partake()
        {
            BookingSingleton.Instance().Partake(new Lecture("d",2,new Room(5),new Collection<User>(),"",new Queue<User>()) , new User());
            //return false;
            return Index();
        }

        public static bool Cancel()
        {
            return false;
        }
    }
}