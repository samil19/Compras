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
    public class MedidasController : Controller
    {
        private ComprasEntities db = new ComprasEntities();

        // GET: Medidas
        public ActionResult Index()
        {
            return View(db.Medidas.ToList());
        }

        // GET: Medidas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medida medida = db.Medidas.Find(id);
            if (medida == null)
            {
                return HttpNotFound();
            }
            return View(medida);
        }

        // GET: Medidas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Medidas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_med,Descripcion,Estado")] Medida medida)
        {
            if (ModelState.IsValid)
            {
                db.Medidas.Add(medida);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(medida);
        }

        // GET: Medidas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medida medida = db.Medidas.Find(id);
            if (medida == null)
            {
                return HttpNotFound();
            }
            return View(medida);
        }

        // POST: Medidas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_med,Descripcion,Estado")] Medida medida)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medida).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medida);
        }

        // GET: Medidas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medida medida = db.Medidas.Find(id);
            if (medida == null)
            {
                return HttpNotFound();
            }
            return View(medida);
        }

        // POST: Medidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Medida medida = db.Medidas.Find(id);
            db.Medidas.Remove(medida);
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
