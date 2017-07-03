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
    public class Articulos_DepartamentosController : Controller
    {
        private ComprasEntities db = new ComprasEntities();

        // GET: Articulos_Departamentos
        public ActionResult Index()
        {
            var articulos_Departamentos = db.Articulos_Departamentos.Include(a => a.Articulo).Include(a => a.Departamento);
            return View(articulos_Departamentos.ToList());
        }

        // GET: Articulos_Departamentos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articulos_Departamentos articulos_Departamentos = db.Articulos_Departamentos.Find(id);
            if (articulos_Departamentos == null)
            {
                return HttpNotFound();
            }
            return View(articulos_Departamentos);
        }

        // GET: Articulos_Departamentos/Create
        public ActionResult Create()
        {
            ViewBag.ID_arti = new SelectList(db.Articulos, "ID_arti", "Descripcion");
            ViewBag.ID_dp = new SelectList(db.Departamentos, "ID_dp", "Nombre");
            return View();
        }

        // POST: Articulos_Departamentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_ardep,ID_arti,ID_dp")] Articulos_Departamentos articulos_Departamentos)
        {
            if (ModelState.IsValid)
            {
                db.Articulos_Departamentos.Add(articulos_Departamentos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_arti = new SelectList(db.Articulos, "ID_arti", "Descripcion", articulos_Departamentos.ID_arti);
            ViewBag.ID_dp = new SelectList(db.Departamentos, "ID_dp", "Nombre", articulos_Departamentos.ID_dp);
            return View(articulos_Departamentos);
        }

        // GET: Articulos_Departamentos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articulos_Departamentos articulos_Departamentos = db.Articulos_Departamentos.Find(id);
            if (articulos_Departamentos == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_arti = new SelectList(db.Articulos, "ID_arti", "Descripcion", articulos_Departamentos.ID_arti);
            ViewBag.ID_dp = new SelectList(db.Departamentos, "ID_dp", "Nombre", articulos_Departamentos.ID_dp);
            return View(articulos_Departamentos);
        }

        // POST: Articulos_Departamentos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_ardep,ID_arti,ID_dp")] Articulos_Departamentos articulos_Departamentos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(articulos_Departamentos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_arti = new SelectList(db.Articulos, "ID_arti", "Descripcion", articulos_Departamentos.ID_arti);
            ViewBag.ID_dp = new SelectList(db.Departamentos, "ID_dp", "Nombre", articulos_Departamentos.ID_dp);
            return View(articulos_Departamentos);
        }

        // GET: Articulos_Departamentos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articulos_Departamentos articulos_Departamentos = db.Articulos_Departamentos.Find(id);
            if (articulos_Departamentos == null)
            {
                return HttpNotFound();
            }
            return View(articulos_Departamentos);
        }

        // POST: Articulos_Departamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Articulos_Departamentos articulos_Departamentos = db.Articulos_Departamentos.Find(id);
            db.Articulos_Departamentos.Remove(articulos_Departamentos);
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
