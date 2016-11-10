using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebProjectCS.Controllers {
    public class HomeController:Controller {
        private DBModelContext db = new DBModelContext();
      public ActionResult Index() {
            TempData.Remove("error");
            return View();
            }
        [HttpPost]
        public ActionResult Index(string exit) {
            usersController.CUser = null;
            return View();
            }
        }
    }