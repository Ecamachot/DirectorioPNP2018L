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
    public class TelefonosController : Controller
    {
        private DirectorioPNPEntities db = new DirectorioPNPEntities();

        // GET: Telefonos
        public ActionResult Index()
        {
            var telefonos = db.Telefonos.Include(t => t.UnidadPNPs);
            return View(telefonos.ToList());
        }

        // GET: Telefonos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Telefonos telefonos = db.Telefonos.Find(id);
            if (telefonos == null)
            {
                return HttpNotFound();
            }
            return View(telefonos);
        }

        // GET: Telefonos/Create
        public ActionResult Create()
        {
            ViewBag.idUnidadPNP = new SelectList(db.UnidadPNPs, "idUnidadPNP", "nombreComun");
            return View();
        }

        // POST: Telefonos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTelefono,numero,tipo,operadora,titular,dateCreate,dateUpdate,isDeleted,userModified,userCreated,idUnidadPNP")] Telefonos telefonos)
        {
            if (ModelState.IsValid)
            {
                db.Telefonos.Add(telefonos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUnidadPNP = new SelectList(db.UnidadPNPs, "idUnidadPNP", "nombreComun", telefonos.idUnidadPNP);
            return View(telefonos);
        }

        // GET: Telefonos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Telefonos telefonos = db.Telefonos.Find(id);
            if (telefonos == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUnidadPNP = new SelectList(db.UnidadPNPs, "idUnidadPNP", "nombreComun", telefonos.idUnidadPNP);
            return View(telefonos);
        }

        // POST: Telefonos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTelefono,numero,tipo,operadora,titular,dateCreate,dateUpdate,isDeleted,userModified,userCreated,idUnidadPNP")] Telefonos telefonos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(telefonos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUnidadPNP = new SelectList(db.UnidadPNPs, "idUnidadPNP", "nombreComun", telefonos.idUnidadPNP);
            return View(telefonos);
        }

        // GET: Telefonos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Telefonos telefonos = db.Telefonos.Find(id);
            if (telefonos == null)
            {
                return HttpNotFound();
            }
            return View(telefonos);
        }

        // POST: Telefonos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Telefonos telefonos = db.Telefonos.Find(id);
            db.Telefonos.Remove(telefonos);
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
