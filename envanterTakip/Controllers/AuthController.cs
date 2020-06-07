using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace envanterTakip.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(user u)
        {
            envanterDBEntities db = new envanterDBEntities();
            var data = db.SP_getLoginDetails(u.user_userName, u.userPassword);
            foreach (var item in data)
            {
                if (item.Username==u.user_userName && item.Password==u.userPassword)
                {
                    Session["Name"] = u.user_userName;
                    return RedirectToAction("Main");
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Remove("name");
            return View("Index");
        }
        public ActionResult Main()
        {
            if (Session["name"]==null)
            {
                return RedirectToAction("Index", "Auth");
            }
            else
            {
                return View();
            }
        }
    }
}