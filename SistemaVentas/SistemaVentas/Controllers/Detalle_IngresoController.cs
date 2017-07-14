using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaVentas.Models;

namespace SistemaVentas.Controllers
{
    public class Detalle_IngresoController : Controller
    {
        private SisVentasContext db = new SisVentasContext();

        // GET: /Detalle_Ingreso/
        public ActionResult Index()
        {
            var detalle_ingreso = db.detalle_ingreso.Include(d => d.articulo).Include(d => d.ingreso);
            return View(detalle_ingreso.ToList());
        }

        // GET: /Detalle_Ingreso/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detalle_ingreso detalle_ingreso = db.detalle_ingreso.Find(id);
            if (detalle_ingreso == null)
            {
                return HttpNotFound();
            }
            return View(detalle_ingreso);
        }

        // GET: /Detalle_Ingreso/Create
        public ActionResult Create()
        {
            ViewBag.idarticulo = new SelectList(db.articuloes, "idarticulo", "codigo");
            ViewBag.idingreso = new SelectList(db.ingresoes, "idingreso", "tipo_comprobante");
            return View();
        }

        // POST: /Detalle_Ingreso/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="iddetalle_ingreso,idingreso,idarticulo,cantidad,precio_compra,precio_venta")] detalle_ingreso detalle_ingreso)
        {
            if (ModelState.IsValid)
            {
                db.detalle_ingreso.Add(detalle_ingreso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idarticulo = new SelectList(db.articuloes, "idarticulo", "codigo", detalle_ingreso.idarticulo);
            ViewBag.idingreso = new SelectList(db.ingresoes, "idingreso", "tipo_comprobante", detalle_ingreso.idingreso);
            return View(detalle_ingreso);
        }

        // GET: /Detalle_Ingreso/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detalle_ingreso detalle_ingreso = db.detalle_ingreso.Find(id);
            if (detalle_ingreso == null)
            {
                return HttpNotFound();
            }
            ViewBag.idarticulo = new SelectList(db.articuloes, "idarticulo", "codigo", detalle_ingreso.idarticulo);
            ViewBag.idingreso = new SelectList(db.ingresoes, "idingreso", "tipo_comprobante", detalle_ingreso.idingreso);
            return View(detalle_ingreso);
        }

        // POST: /Detalle_Ingreso/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="iddetalle_ingreso,idingreso,idarticulo,cantidad,precio_compra,precio_venta")] detalle_ingreso detalle_ingreso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalle_ingreso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idarticulo = new SelectList(db.articuloes, "idarticulo", "codigo", detalle_ingreso.idarticulo);
            ViewBag.idingreso = new SelectList(db.ingresoes, "idingreso", "tipo_comprobante", detalle_ingreso.idingreso);
            return View(detalle_ingreso);
        }

        // GET: /Detalle_Ingreso/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detalle_ingreso detalle_ingreso = db.detalle_ingreso.Find(id);
            if (detalle_ingreso == null)
            {
                return HttpNotFound();
            }
            return View(detalle_ingreso);
        }

        // POST: /Detalle_Ingreso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            detalle_ingreso detalle_ingreso = db.detalle_ingreso.Find(id);
            db.detalle_ingreso.Remove(detalle_ingreso);
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
