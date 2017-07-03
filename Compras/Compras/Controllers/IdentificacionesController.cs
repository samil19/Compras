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
    public class IdentificacionesController : Controller
    {
        private ComprasEntities db = new ComprasEntities();

        // GET: Identificaciones
        public ActionResult Index()
        {
            return View(db.Identificacions.ToList());
        }

        // GET: Identificaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Identificacion identificacion = db.Identificacions.Find(id);
            if (identificacion == null)
            {
                return HttpNotFound();
            }
            return View(identificacion);
        }

        // GET: Identificaciones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Identificaciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_ID,Numero_ID,Tipo")] Identificacion identificacion)
        {
            if (ModelState.IsValid)
            {
                db.Identificacions.Add(identificacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(identificacion);
        }

        // GET: Identificaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Identificacion identificacion = db.Identificacions.Find(id);
            if (identificacion == null)
            {
                return HttpNotFound();
            }
            return View(identificacion);
        }

        // POST: Identificaciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_ID,Numero_ID,Tipo")] Identificacion identificacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(identificacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(identificacion);
        }

        // GET: Identificaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Identificacion identificacion = db.Identificacions.Find(id);
            if (identificacion == null)
            {
                return HttpNotFound();
            }
            return View(identificacion);
        }

        // POST: Identificaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Identificacion identificacion = db.Identificacions.Find(id);
            db.Identificacions.Remove(identificacion);
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
