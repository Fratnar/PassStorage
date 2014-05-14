using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PassStorage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PassStorage.Controllers
{
    public class HomeController : Controller
    {
        ServicesDb _db = new ServicesDb();

        public ActionResult Index()
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_db));
            //var currentUser = UserManager.FindById(User.Identity.GetUserId());

            var services = from key in _db.Services
                           select key;

            var model = _db.Services.Single(x => x.Id == 11);

            return View(services);
        }
    }
}