using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Consomi.Data;
using Consomi.Domain.Entities;

namespace Consomi.Web.Controllers
{
    public class LivreurController : Controller
    {
        private ConsomiContext db = new ConsomiContext();

        // GET: Livreur
        public ActionResult Index()
        {
            return View(db.Livreur.ToList());
        }


        // GET: Livreur/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livreur livreur = db.Livreur.Find(id);
            if (livreur == null)
            {
                return HttpNotFound();
            }
            return View(livreur);
        }

        // GET: Livreur/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Livreur/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Mail,Nom,Prenom,Password")] Livreur livreur)
        {
            if (ModelState.IsValid)
            {
                db.Livreur.Add(livreur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(livreur);
        }

        // GET: Livreur/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livreur livreur = db.Livreur.Find(id);
            if (livreur == null)
            {
                return HttpNotFound();
            }
            return View(livreur);
        }

        // POST: Livreur/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Mail,Nom,Prenom,Password")] Livreur livreur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(livreur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(livreur);
        }

        // GET: Livreur/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livreur livreur = db.Livreur.Find(id);
            if (livreur == null)
            {
                return HttpNotFound();
            }
            return View(livreur);
        }

        // POST: Livreur/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Livreur livreur = db.Livreur.Find(id);
            db.Livreur.Remove(livreur);
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
