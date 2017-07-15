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
    public class ArticuloController : Controller
    {
        private SisVentasContext db = new SisVentasContext();

        // GET: /Articulo/
        public ActionResult Index()
        {
            var articuloes = db.articuloes.Include(a => a.categoria);
            return View(articuloes.ToList());
        }

        // GET: /Articulo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            articulo articulo = db.articuloes.Find(id);
            if (articulo == null)
            {
                return HttpNotFound();
            }
            return View(articulo);
        }

        // GET: /Articulo/Create
        public ActionResult Create()
        {
            ViewBag.idcategoria = new SelectList(db.categorias, "idcategoria", "nombre");
            return View();
        }

        // POST: /Articulo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="idarticulo,idcategoria,codigo,nombre,stock,descripcion,imagen,estado")] articulo articulo, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null) {

                    string archivo = (file.FileName).ToLower();
                    file.SaveAs(Server.MapPath("~/Uploads/" + archivo));
                    articulo.imagen = archivo;
                
                }
                db.articuloes.Add(articulo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idcategoria = new SelectList(db.categorias, "idcategoria", "nombre", articulo.idcategoria);
            return View(articulo);
        }

        // GET: /Articulo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            articulo articulo = db.articuloes.Find(id);
            if (articulo == null)
            {
                return HttpNotFound();
            }
            ViewBag.idcategoria = new SelectList(db.categorias, "idcategoria", "nombre", articulo.idcategoria);
            return View(articulo);
        }

        // POST: /Articulo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="idarticulo,idcategoria,codigo,nombre,stock,descripcion,imagen,estado")] articulo articulo)
        {
            if (ModelState.IsValid)
            {

                db.Entry(articulo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idcategoria = new SelectList(db.categorias, "idcategoria", "nombre", articulo.idcategoria);
            return View(articulo);
        }

        // GET: /Articulo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            articulo articulo = db.articuloes.Find(id);
            if (articulo == null)
            {
                return HttpNotFound();
            }
            return View(articulo);
        }

        // POST: /Articulo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            articulo articulo = db.articuloes.Find(id);
            db.articuloes.Remove(articulo);
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
