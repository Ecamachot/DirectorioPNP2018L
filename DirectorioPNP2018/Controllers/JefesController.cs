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
    public class JefesController : Controller
    {
        private DirectorioPNPEntities db = new DirectorioPNPEntities();

        // GET: Jefes
        public ActionResult Index()
        {
            return View(db.Jefes.ToList());
        }

        // GET: Jefes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jefes jefes = db.Jefes.Find(id);
            if (jefes == null)
            {
                return HttpNotFound();
            }
            return View(jefes);
        }

        // GET: Jefes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jefes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idJefe,cip,grado,apPaterno,apMaterno,nombres,celularP,dateCreate,dateUpdate,isDeleted,userModified,userCreated")] Jefes jefes)
        {
            if (ModelState.IsValid)
            {
                db.Jefes.Add(jefes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jefes);
        }

        // GET: Jefes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jefes jefes = db.Jefes.Find(id);
            if (jefes == null)
            {
                return HttpNotFound();
            }
            return View(jefes);
        }

        // POST: Jefes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idJefe,cip,grado,apPaterno,apMaterno,nombres,celularP,dateCreate,dateUpdate,isDeleted,userModified,userCreated")] Jefes jefes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jefes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jefes);
        }

        // GET: Jefes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jefes jefes = db.Jefes.Find(id);
            if (jefes == null)
            {
                return HttpNotFound();
            }
            return View(jefes);
        }

        // POST: Jefes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Jefes jefes = db.Jefes.Find(id);
            db.Jefes.Remove(jefes);
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
