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
    public class Detalle_VentaController : Controller
    {
        private SisVentasContext db = new SisVentasContext();

        // GET: /Detalle_Venta/
        public ActionResult Index()
        {
            var detalle_venta = db.detalle_venta.Include(d => d.articulo).Include(d => d.venta);
            return View(detalle_venta.ToList());
        }

        // GET: /Detalle_Venta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detalle_venta detalle_venta = db.detalle_venta.Find(id);
            if (detalle_venta == null)
            {
                return HttpNotFound();
            }
            return View(detalle_venta);
        }

        // GET: /Detalle_Venta/Create
        public ActionResult Create()
        {
            ViewBag.idarticulo = new SelectList(db.articuloes, "idarticulo", "codigo");
            ViewBag.idventa = new SelectList(db.ventas, "idventa", "tipo_comprobante");
            return View();
        }

        // POST: /Detalle_Venta/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="iddetalle_venta,idventa,idarticulo,cantidad,precio_venta,descuento")] detalle_venta detalle_venta)
        {
            if (ModelState.IsValid)
            {
                db.detalle_venta.Add(detalle_venta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idarticulo = new SelectList(db.articuloes, "idarticulo", "codigo", detalle_venta.idarticulo);
            ViewBag.idventa = new SelectList(db.ventas, "idventa", "tipo_comprobante", detalle_venta.idventa);
            return View(detalle_venta);
        }

        // GET: /Detalle_Venta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detalle_venta detalle_venta = db.detalle_venta.Find(id);
            if (detalle_venta == null)
            {
                return HttpNotFound();
            }
            ViewBag.idarticulo = new SelectList(db.articuloes, "idarticulo", "codigo", detalle_venta.idarticulo);
            ViewBag.idventa = new SelectList(db.ventas, "idventa", "tipo_comprobante", detalle_venta.idventa);
            return View(detalle_venta);
        }

        // POST: /Detalle_Venta/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="iddetalle_venta,idventa,idarticulo,cantidad,precio_venta,descuento")] detalle_venta detalle_venta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalle_venta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idarticulo = new SelectList(db.articuloes, "idarticulo", "codigo", detalle_venta.idarticulo);
            ViewBag.idventa = new SelectList(db.ventas, "idventa", "tipo_comprobante", detalle_venta.idventa);
            return View(detalle_venta);
        }

        // GET: /Detalle_Venta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detalle_venta detalle_venta = db.detalle_venta.Find(id);
            if (detalle_venta == null)
            {
                return HttpNotFound();
            }
            return View(detalle_venta);
        }

        // POST: /Detalle_Venta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            detalle_venta detalle_venta = db.detalle_venta.Find(id);
            db.detalle_venta.Remove(detalle_venta);
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
