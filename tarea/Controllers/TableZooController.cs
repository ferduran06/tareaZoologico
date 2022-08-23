using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using tarea.Models;
using tarea.Models.viewModels;

namespace tarea.Controllers
{
    public class TableZooController : Controller
    {
        private bdZooEntities db = new bdZooEntities();

        // GET: TableZoo
        public ActionResult Index()
        {
            return View(db.tableZoos.ToList());
        }

        // GET: TableZoo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tableZoo tableZoo = db.tableZoos.Find(id);
            if (tableZoo == null)
            {
                return HttpNotFound();
            }
            return View(tableZoo);
        }

        // GET: TableZoo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TableZoo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,pais,nombre,telefono,sitioWeb")] tableZoo tableZoo)
        {
            if (ModelState.IsValid)
            {
                db.tableZoos.Add(tableZoo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tableZoo);
        }

        // GET: TableZoo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tableZoo tableZoo = db.tableZoos.Find(id);
            if (tableZoo == null)
            {
                return HttpNotFound();
            }
            return View(tableZoo);
        }

        // POST: TableZoo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,pais,nombre,telefono,sitioWeb")] tableZoo tableZoo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tableZoo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tableZoo);
        }

        // GET: TableZoo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tableZoo tableZoo = db.tableZoos.Find(id);
            if (tableZoo == null)
            {
                return HttpNotFound();
            }
            return View(tableZoo);
        }

        // POST: TableZoo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tableZoo tableZoo = db.tableZoos.Find(id);
            db.tableZoos.Remove(tableZoo);
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
