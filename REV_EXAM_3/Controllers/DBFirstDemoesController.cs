using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using REV_EXAM_3.Models;

namespace REV_EXAM_3.Controllers
{
    public class DBFirstDemoesController : Controller
    {
        private REV_EXAM_3Context db = new REV_EXAM_3Context();

        // GET: DBFirstDemoes
        public ActionResult Index()
        {
            return View(db.DBFirstDemoes.ToList());
        }

        // GET: DBFirstDemoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DBFirstDemo dBFirstDemo = db.DBFirstDemoes.Find(id);
            if (dBFirstDemo == null)
            {
                return HttpNotFound();
            }
            return View(dBFirstDemo);
        }

        // GET: DBFirstDemoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DBFirstDemoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,value1,value2,value4")] DBFirstDemo dBFirstDemo)
        {
            if (ModelState.IsValid)
            {
                db.DBFirstDemoes.Add(dBFirstDemo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dBFirstDemo);
        }

        // GET: DBFirstDemoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DBFirstDemo dBFirstDemo = db.DBFirstDemoes.Find(id);
            if (dBFirstDemo == null)
            {
                return HttpNotFound();
            }
            return View(dBFirstDemo);
        }

        // POST: DBFirstDemoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,value1,value2,value4")] DBFirstDemo dBFirstDemo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dBFirstDemo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dBFirstDemo);
        }

        // GET: DBFirstDemoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DBFirstDemo dBFirstDemo = db.DBFirstDemoes.Find(id);
            if (dBFirstDemo == null)
            {
                return HttpNotFound();
            }
            return View(dBFirstDemo);
        }

        // POST: DBFirstDemoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DBFirstDemo dBFirstDemo = db.DBFirstDemoes.Find(id);
            db.DBFirstDemoes.Remove(dBFirstDemo);
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
