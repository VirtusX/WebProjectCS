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
    public class GamesController : Controller
    {
        private DBModelContext db = new DBModelContext();
        private static DBModelContext sdb = new DBModelContext();
        private static int? id = null;
        private static bool edit = false;
        public ActionResult Index(int game)
        {
            if(usersController.CUser == null)
                return RedirectToAction("index", "home");
            id = game;
            return View();
        }

        public ActionResult Edit(string edit, int? game)
        {
            if(usersController.CUser == null)
                return RedirectToAction("index", "home");
            GamesController.edit = edit.Equals("true");
            id = game;
            return View();
        }


        [HttpPost]
        public ActionResult Edit([Bind(Include = "game_name,game_authors,game_pic,game_about")] games game)
        {
            var find = from g in db.games
                       where g.game_name == game.game_name
                       select g;
            games EditGame = Game();
            if(edit) {
                if(find.Count() > 0 && !Game().game_name.Equals(game.game_name))
                    return View();
                if(game.game_name != null)
                    EditGame.game_name = game.game_name;
                if(game.game_authors != null)
                    EditGame.game_authors = game.game_authors;
                if(game.game_pic != null)
                    EditGame.game_pic = game.game_pic;
                if(game.game_about != null)
                    EditGame.game_about = game.game_about;
                db.Entry(Game()).CurrentValues.SetValues(EditGame);
                db.SaveChanges();
                return RedirectToAction("../games/index?game=" + EditGame.game_id);
                }

            else if(!edit) {
                if(find.Count() > 0)
                    return View();
                EditGame = game;
                var last = (from n in db.games
                            select n.game_id).Max();
                EditGame.game_id = last + 1;
                db.games.Add(EditGame);
                db.SaveChanges();
                user_games ug = new user_games();
                ug.game_id = (from g in db.games
                             where g.game_name == game.game_name
                             select g.game_id).Single();
                ug.user_id = usersController.CUser.user_id;
                db.user_games.Add(ug);
                db.SaveChanges();
                return RedirectToAction("../users/edit");
                }
            return View();
        }

       public static games Game() {
            var Game = from g in sdb.games
                       where g.game_id == id
                       select g;
            if(Game.Count() == 0)
                return null;
            return Game.Single();
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
