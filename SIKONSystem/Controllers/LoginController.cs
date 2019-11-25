using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using System.Web.Security;

namespace SIKONSystem.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

    //    [HttpPost]
    //    public ActionResult Index(Models.Login request)
    //    {
    //        if (!ModelState.IsValid) return View(request);

    //        if (!string.IsNullOrEmpty(request.Username) && !string.IsNullOrEmpty(request.Password))
    //        {
    //           // FormsAuthentication.SetAuthCookie(request.Username, false);
    //           //& return Redirect(FormsAuthentication.GetRedirectUrl(request.Username, false));
    //           return
    //        }

    //        ViewBag.Failed = true;
    //        return View(request);
    //    }
    }
    
}