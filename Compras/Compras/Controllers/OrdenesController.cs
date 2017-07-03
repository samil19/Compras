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
    public class OrdenesController : Controller
    {
        private ComprasEntities db = new ComprasEntities();

        // GET: Ordenes
        public ActionResult Index()
        {
            var ordenes = db.Ordenes.Include(o => o.Articulo).Include(o => o.Medida).Include(o => o.Proveedore);
            return View(ordenes.ToList());
        }

        // GET: Ordenes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ordene ordene = db.Ordenes.Find(id);
            if (ordene == null)
            {
                return HttpNotFound();
            }
            return View(ordene);
        }

        // GET: Ordenes/Create
        public ActionResult Create()
        {
            ViewBag.ID_arti = new SelectList(db.Articulos, "ID_arti", "Descripcion");
            ViewBag.ID_med = new SelectList(db.Medidas, "ID_med", "Descripcion");
            ViewBag.ID_prov = new SelectList(db.Proveedores, "ID_prov", "Nombre");
            return View();
        }

        // POST: Ordenes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Num_orden,Fecha,Estado,ID_arti,Cantidad,ID_med,Unitario,Total,ID_prov")] Ordene ordene)
        {
            if (ModelState.IsValid)
            {
                db.Ordenes.Add(ordene);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_arti = new SelectList(db.Articulos, "ID_arti", "Descripcion", ordene.ID_arti);
            ViewBag.ID_med = new SelectList(db.Medidas, "ID_med", "Descripcion", ordene.ID_med);
            ViewBag.ID_prov = new SelectList(db.Proveedores, "ID_prov", "Nombre", ordene.ID_prov);
            return View(ordene);
        }

        // GET: Ordenes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ordene ordene = db.Ordenes.Find(id);
            if (ordene == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_arti = new SelectList(db.Articulos, "ID_arti", "Descripcion", ordene.ID_arti);
            ViewBag.ID_med = new SelectList(db.Medidas, "ID_med", "Descripcion", ordene.ID_med);
            ViewBag.ID_prov = new SelectList(db.Proveedores, "ID_prov", "Nombre", ordene.ID_prov);
            return View(ordene);
        }

        // POST: Ordenes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Num_orden,Fecha,Estado,ID_arti,Cantidad,ID_med,Unitario,Total,ID_prov")] Ordene ordene)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordene).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_arti = new SelectList(db.Articulos, "ID_arti", "Descripcion", ordene.ID_arti);
            ViewBag.ID_med = new SelectList(db.Medidas, "ID_med", "Descripcion", ordene.ID_med);
            ViewBag.ID_prov = new SelectList(db.Proveedores, "ID_prov", "Nombre", ordene.ID_prov);
            return View(ordene);
        }

        // GET: Ordenes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ordene ordene = db.Ordenes.Find(id);
            if (ordene == null)
            {
                return HttpNotFound();
            }
            return View(ordene);
        }

        // POST: Ordenes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ordene ordene = db.Ordenes.Find(id);
            db.Ordenes.Remove(ordene);
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
