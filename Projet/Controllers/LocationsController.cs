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
    public class LocationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Locations
        public ActionResult Index()
        {
            var locations = db.Locations.Include(l => l.Agence).Include(l => l.Client).Include(l => l.Vehicule);
            return View(locations.ToList());
        }

        // GET: Locations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = db.Locations.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        // GET: Locations/Create
        public ActionResult Create()
        {
            ViewBag.IdAgence = new SelectList(db.Agences.Where(a => a.Etat == false), "IdAgence", "Ville");
            ViewBag.IdClient = new SelectList(db.Clients, "IdClient", "Nom");
            ViewBag.IdVehicule = new SelectList(db.Vehicules.Where(v => v.Etat == false), "IdVehicule", "Modele");
            return View();
        }

        // POST: Locations/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdLocation,DateDebut,DateFin,Prix,IdClient,IdAgence,IdVehicule")] Location location)
        {
            if (ModelState.IsValid)
            {
                int? id = location.IdVehicule;
                Vehicule vehicule = db.Vehicules.Find(id);
                vehicule.Etat = true;
                db.Locations.Add(location);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdAgence = new SelectList(db.Agences, "IdAgence", "Ville", location.IdAgence);
            ViewBag.IdClient = new SelectList(db.Clients, "IdClient", "Nom", location.IdClient);
            ViewBag.IdVehicule = new SelectList(db.Vehicules, "IdVehicule", "Modele", location.IdVehicule);
            return View(location);
        }

        // GET: Locations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = db.Locations.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdAgence = new SelectList(db.Agences, "IdAgence", "Ville", location.IdAgence);
            ViewBag.IdClient = new SelectList(db.Clients, "IdClient", "Nom", location.IdClient);
            ViewBag.IdVehicule = new SelectList(db.Vehicules, "IdVehicule", "Marque", location.IdVehicule);
            return View(location);
        }

        // POST: Locations/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdLocation,DateDebut,DateFin,Prix,IdClient,IdAgence,IdVehicule")] Location location)
        {
            if (ModelState.IsValid)
            {
                db.Entry(location).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdAgence = new SelectList(db.Agences, "IdAgence", "Ville", location.IdAgence);
            ViewBag.IdClient = new SelectList(db.Clients, "IdClient", "Nom", location.IdClient);
            ViewBag.IdVehicule = new SelectList(db.Vehicules, "IdVehicule", "Marque", location.IdVehicule);
            return View(location);
        }

        // GET: Locations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = db.Locations.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        // POST: Locations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Location location = db.Locations.Find(id);
            db.Locations.Remove(location);
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
