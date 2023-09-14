using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnLapTrinhWeb.Identity;
using DoAnLapTrinhWeb.Filters;

namespace DoAnLapTrinhWeb.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class UsersController : Controller
    {
        // GET: Admin/User
        public ActionResult Index()
        {
            AppDbContext db = new AppDbContext();
            List<AppUser> users = db.Users.ToList();
            return View(users);
        }
    }
}