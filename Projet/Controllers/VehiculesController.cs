using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Projet.Models;

namespace Projet.Controllers
{
    public class VehiculesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Vehicules
        public ActionResult Index()
        {
            var vehicules = db.Vehicules.Include(v => v.Agence);
            return View(vehicules.ToList());
        }

        // GET: Vehicules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicule vehicule = db.Vehicules.Find(id);
            if (vehicule == null)
            {
                return HttpNotFound();
            }
            return View(vehicule);
        }

        // GET: Vehicules/Create
        public ActionResult Create()
        {
            ViewBag.AgenceId = new SelectList(db.Agences, "IdAgence", "Ville");
            return View();
        }

        // POST: Vehicules/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdVehicule,Marque,Modele,Immatricule,Couleur,Km,Etat,AgenceId")] Vehicule vehicule)
        {
            if (ModelState.IsValid)
            {
                db.Vehicules.Add(vehicule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AgenceId = new SelectList(db.Agences, "IdAgence", "Ville", vehicule.AgenceId);
            return View(vehicule);
        }

        // GET: Vehicules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicule vehicule = db.Vehicules.Find(id);
            if (vehicule == null)
            {
                return HttpNotFound();
            }
            ViewBag.AgenceId = new SelectList(db.Agences, "IdAgence", "Ville", vehicule.AgenceId);
            return View(vehicule);
        }

        // POST: Vehicules/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdVehicule,Marque,Modele,Immatricule,Couleur,Km,Etat,AgenceId")] Vehicule vehicule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AgenceId = new SelectList(db.Agences, "IdAgence", "Ville", vehicule.AgenceId);
            return View(vehicule);
        }

        // GET: Vehicules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicule vehicule = db.Vehicules.Find(id);
            if (vehicule == null)
            {
                return HttpNotFound();
            }
            return View(vehicule);
        }

        // POST: Vehicules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehicule vehicule = db.Vehicules.Find(id);
            db.Vehicules.Remove(vehicule);
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

        public ActionResult Disponnible()
        {
            var vehicules = db.Vehicules.Where(v => v.Etat == false).Include(v => v.Agence);
            return View(vehicules.ToList());
        }
    }
}
