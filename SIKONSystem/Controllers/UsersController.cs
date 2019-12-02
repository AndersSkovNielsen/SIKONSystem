using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SIKONSystem.Models;

namespace SIKONSystem.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult CreateUser()
        {
            return View();
        }

        public IActionResult Create(User user)
        {
            UserSingleton.Instance().Create(user);
            return RedirectToAction("Profile");
        }
    }
}