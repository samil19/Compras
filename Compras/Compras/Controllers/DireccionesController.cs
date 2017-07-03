using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Compras;

namespace Compras.Controllers
{
    public class DireccionesController : Controller
    {
        private ComprasEntities db = new ComprasEntities();

        // GET: Direcciones
        public ActionResult Index()
        {
            return View(db.Direccions.ToList());
        }

        // GET: Direcciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direccion direccion = db.Direccions.Find(id);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            return View(direccion);
        }

        // GET: Direcciones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Direcciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_direccion,Direccion1,Latitud,Longitud")] Direccion direccion)
        {
            if (ModelState.IsValid)
            {
                db.Direccions.Add(direccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(direccion);
        }

        // GET: Direcciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direccion direccion = db.Direccions.Find(id);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            return View(direccion);
        }

        // POST: Direcciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_direccion,Direccion1,Latitud,Longitud")] Direccion direccion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(direccion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(direccion);
        }

        // GET: Direcciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direccion direccion = db.Direccions.Find(id);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            return View(direccion);
        }

        // POST: Direcciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Direccion direccion = db.Direccions.Find(id);
            db.Direccions.Remove(direccion);
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
