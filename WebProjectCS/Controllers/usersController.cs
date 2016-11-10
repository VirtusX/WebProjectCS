using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebProjectCS;

namespace WebProjectCS.Controllers
{
    public class usersController : Controller
    {
        private DBModelContext db = new DBModelContext();
        public static User CUser = null;
        private static DBModelContext sdb = new DBModelContext();
        public ActionResult Index()
        {
            if(CUser != null)
                return RedirectToAction("index", "home");
            return View();
        }


        public ActionResult Create()
        {
            if(CUser != null)
                return RedirectToAction("index", "home");
            return View();
        }
  

        public ActionResult Edit() {
            if(CUser == null)
                return RedirectToAction("index", "home");
            return View();
        }


        [HttpPost]
        public ActionResult Edit([Bind(Include = "user_name,user_password,user_email,user_pic,user_birthday,user_location,user_about")] User users)
        {
            if (ModelState.IsValid)
            {
                db.Entry(users).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Index([Bind(Include = "user_name,user_password")] User users) {
            User User;
            try {
                User = (from u in db.users
                        where u.user_name == users.user_name
                        where u.user_password == users.user_password
                        select u).Single();
                }
            catch(Exception ex) {
                TempData["error"] = "login error";
                return View();
                }
            TempData.Remove("error");
            CUser = User;
            return RedirectToAction("index", "home");
            }


        [HttpPost]
        public ActionResult Create([Bind(Include = "user_name,user_password,user_email")] User users) {
            var hasUser = from u in db.users
                          where u.user_name == users.user_name
                          select u;
            if(hasUser.Count() > 0) {
                TempData["error"] = "sign up error";
                return View();
                }
            TempData.Remove("error");
            db.users.Add(users);
            CUser = users;
            db.SaveChanges();
            return RedirectToAction("index", "home");
            }

        public static List<games> UserGames() {
            var games = from g in sdb.games
                      where (from u in sdb.user_games
                              where u.user_id == CUser.user_id
                              select u.game_id).Contains(g.game_id)
                      select g;
            return games.ToList();
            }

        public static IQueryable<string> GamesList() {
            var uGame = from g in sdb.games
                        where !(from u in sdb.user_games
                               where u.user_id == CUser.user_id
                               select u.game_id).Contains(g.game_id)
                               select g.game_name;
            return uGame;
            }

        public static List<string> UserData() {
            var Data = new List<string>();
            System.Globalization.CultureInfo co = new System.Globalization.CultureInfo("en-US");
            Data.Add("User name: " + CUser.user_name);
            if(CUser.user_birthday != null)
                Data.Add("User birthday: " + string.Format(co,"{0: d MMM yyyy }",CUser.user_birthday));
            if(CUser.user_location != null)
                Data.Add("User Location: " + CUser.user_location);
            if(CUser.user_about != null)
                Data.Add("About user: " + CUser.user_about);
            return Data;
            }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
