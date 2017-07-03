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
    public class ProveedoresController : Controller
    {
        private ComprasEntities db = new ComprasEntities();

        // GET: Proveedores
        public ActionResult Index()
        {
            var proveedores = db.Proveedores.Include(p => p.Direccion).Include(p => p.Identificacion);
            return View(proveedores.ToList());
        }

        // GET: Proveedores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proveedore proveedore = db.Proveedores.Find(id);
            if (proveedore == null)
            {
                return HttpNotFound();
            }
            return View(proveedore);
        }

        // GET: Proveedores/Create
        public ActionResult Create()
        {
            ViewBag.ID_Direccion = new SelectList(db.Direccions, "ID_direccion", "Direccion1");
            ViewBag.ID_ID = new SelectList(db.Identificacions, "ID_ID", "Numero_ID");
            return View();
        }

        // POST: Proveedores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_prov,ID_ID,Nombre,Estado,ID_Direccion")] Proveedore proveedore)
        {
            if (ModelState.IsValid)
            {
                db.Proveedores.Add(proveedore);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Direccion = new SelectList(db.Direccions, "ID_direccion", "Direccion1", proveedore.ID_Direccion);
            ViewBag.ID_ID = new SelectList(db.Identificacions, "ID_ID", "Tipo", proveedore.ID_ID);
            return View(proveedore);
        }

        // GET: Proveedores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proveedore proveedore = db.Proveedores.Find(id);
            if (proveedore == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Direccion = new SelectList(db.Direccions, "ID_direccion", "Direccion1", proveedore.ID_Direccion);
            ViewBag.ID_ID = new SelectList(db.Identificacions, "ID_ID", "Tipo", proveedore.ID_ID);
            return View(proveedore);
        }

        // POST: Proveedores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_prov,ID_ID,Nombre,Estado,ID_Direccion")] Proveedore proveedore)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proveedore).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Direccion = new SelectList(db.Direccions, "ID_direccion", "Direccion1", proveedore.ID_Direccion);
            ViewBag.ID_ID = new SelectList(db.Identificacions, "ID_ID", "Tipo", proveedore.ID_ID);
            return View(proveedore);
        }

        // GET: Proveedores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proveedore proveedore = db.Proveedores.Find(id);
            if (proveedore == null)
            {
                return HttpNotFound();
            }
            return View(proveedore);
        }

        // POST: Proveedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Proveedore proveedore = db.Proveedores.Find(id);
            db.Proveedores.Remove(proveedore);
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
