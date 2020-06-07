using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using envanterTakip;

namespace envanterTakip.Controllers
{
    public class usersController : Controller
    {
        private envanterDBEntities db = new envanterDBEntities();

        // GET: users
        public ActionResult Index()
        {
            var users = db.users.Include(u => u.role);
            return View(users.ToList());
        }

        // GET: users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        private void createCombo()
        {
            List<SelectListItem> li = new List<SelectListItem>();
            li.Add(new SelectListItem() { Text = "Aktif", Value = "1" });
            li.Add(new SelectListItem() { Text = "Pasif", Value = "0" });
            ViewBag.abc = new SelectList(li, "Value", "Text");
        }

        // GET: users/Create
        public ActionResult Create()
        {
            createCombo();

            ViewBag.userRoleId = new SelectList(db.roles, "roleId", "roleName");
            return View();
        }

        // POST: users/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "userId,userName,user_userName,userPassword,userPhone,userEmail,userStatus,userRoleId")] user user)
        {
            if (ModelState.IsValid)
            {
                db.users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            List<SelectListItem> li = new List<SelectListItem>();
            li.Add(new SelectListItem() { Text = "Aktif", Value = "1" });
            li.Add(new SelectListItem() { Text = "Pasif", Value = "0" });
            ViewBag.abc = new SelectList(li, "Value", "Text");

            ViewBag.userRoleId = new SelectList(db.roles, "roleId", "roleName", user.userRoleId);
            return View(user);
        }

        // GET: users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            List<SelectListItem> li = new List<SelectListItem>();
            li.Add(new SelectListItem() { Text = "Aktif", Value = "1" });
            li.Add(new SelectListItem() { Text = "Pasif", Value = "0" });
            ViewBag.abc = new SelectList(li, "Value", "Text");

            ViewBag.userRoleId = new SelectList(db.roles, "roleId", "roleName", user.userRoleId);
            return View(user);
        }

        // POST: users/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "userId,userName,user_userName,userPassword,userPhone,userEmail,userStatus,userRoleId")] user user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            List<SelectListItem> li = new List<SelectListItem>();
            li.Add(new SelectListItem() { Text = "Aktif", Value = "1" });
            li.Add(new SelectListItem() { Text = "Pasif", Value = "0" });
            ViewBag.abc = new SelectList(li, "Value", "Text");
            ViewBag.userRoleId = new SelectList(db.roles, "roleId", "roleName", user.userRoleId);
            return View(user);
        }

        // GET: users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            user user = db.users.Find(id);
            db.users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
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
