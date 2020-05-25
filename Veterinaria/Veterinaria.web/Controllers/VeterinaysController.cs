using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Veterinaria.web.Models;

namespace Veterinaria.web.Controllers
{
    public class VeterinaysController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Veterinays
        public ActionResult Index()
        {
            return View(db.Veterinays.ToList());
        }

        // GET: Veterinays/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veterinay veterinay = db.Veterinays.Find(id);
            if (veterinay == null)
            {
                return HttpNotFound();
            }
            return View(veterinay);
        }

        // GET: Veterinays/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Veterinays/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description")] Veterinay veterinay)
        {
            if (ModelState.IsValid)
            {
                db.Veterinays.Add(veterinay);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(veterinay);
        }

        // GET: Veterinays/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veterinay veterinay = db.Veterinays.Find(id);
            if (veterinay == null)
            {
                return HttpNotFound();
            }
            return View(veterinay);
        }

        // POST: Veterinays/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description")] Veterinay veterinay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(veterinay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(veterinay);
        }

        // GET: Veterinays/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veterinay veterinay = db.Veterinays.Find(id);
            if (veterinay == null)
            {
                return HttpNotFound();
            }
            return View(veterinay);
        }

        // POST: Veterinays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Veterinay veterinay = db.Veterinays.Find(id);
            db.Veterinays.Remove(veterinay);
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
