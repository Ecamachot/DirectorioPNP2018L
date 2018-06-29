using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DirectorioPNP2018.Models;

namespace DirectorioPNP2018.Controllers
{
    public class UnidadPNPsController : Controller
    {
        private DirectorioPNPEntities db = new DirectorioPNPEntities();

        // GET: UnidadPNPs
        public ActionResult Index()
        {
            var unidadPNPs = db.UnidadPNPs.Include(u => u.Jefes);
            return View(unidadPNPs.ToList());
        }

        // GET: UnidadPNPs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnidadPNPs unidadPNPs = db.UnidadPNPs.Find(id);
            if (unidadPNPs == null)
            {
                return HttpNotFound();
            }
            return View(unidadPNPs);
        }

        // GET: UnidadPNPs/Create
        public ActionResult Create()
        {
            ViewBag.idJefe = new SelectList(db.Jefes, "idJefe", "cip");
            return View();
        }

        // POST: UnidadPNPs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idUnidadPNP,nombreComun,nombreOficial,correo,calle,distrito,provincia,departamento,dateCreate,dateUpdate,isDeleted,userModified,userCreated,idJefe")] UnidadPNPs unidadPNPs)
        {
            if (ModelState.IsValid)
            {
                db.UnidadPNPs.Add(unidadPNPs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idJefe = new SelectList(db.Jefes, "idJefe", "cip", unidadPNPs.idJefe);
            return View(unidadPNPs);
        }

        // GET: UnidadPNPs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnidadPNPs unidadPNPs = db.UnidadPNPs.Find(id);
            if (unidadPNPs == null)
            {
                return HttpNotFound();
            }
            ViewBag.idJefe = new SelectList(db.Jefes, "idJefe", "cip", unidadPNPs.idJefe);
            return View(unidadPNPs);
        }

        // POST: UnidadPNPs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idUnidadPNP,nombreComun,nombreOficial,correo,calle,distrito,provincia,departamento,dateCreate,dateUpdate,isDeleted,userModified,userCreated,idJefe")] UnidadPNPs unidadPNPs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unidadPNPs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idJefe = new SelectList(db.Jefes, "idJefe", "cip", unidadPNPs.idJefe);
            return View(unidadPNPs);
        }

        // GET: UnidadPNPs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnidadPNPs unidadPNPs = db.UnidadPNPs.Find(id);
            if (unidadPNPs == null)
            {
                return HttpNotFound();
            }
            return View(unidadPNPs);
        }

        // POST: UnidadPNPs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UnidadPNPs unidadPNPs = db.UnidadPNPs.Find(id);
            db.UnidadPNPs.Remove(unidadPNPs);
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
