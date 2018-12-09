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
    public class BasicDemoClassesController : Controller
    {
        private REV_EXAM_3Context db = new REV_EXAM_3Context();

        // GET: BasicDemoClasses
        public ActionResult Index()
        {
            return View(db.BasicDemoClasses.ToList());
        }

        // GET: BasicDemoClasses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BasicDemoClass basicDemoClass = db.BasicDemoClasses.Find(id);
            if (basicDemoClass == null)
            {
                return HttpNotFound();
            }
            return View(basicDemoClass);
        }

        // GET: BasicDemoClasses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BasicDemoClasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "myPk,name1,randomeDate")] BasicDemoClass basicDemoClass)
        {
            if (ModelState.IsValid)
            {
                db.BasicDemoClasses.Add(basicDemoClass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(basicDemoClass);
        }

        // GET: BasicDemoClasses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BasicDemoClass basicDemoClass = db.BasicDemoClasses.Find(id);
            if (basicDemoClass == null)
            {
                return HttpNotFound();
            }
            return View(basicDemoClass);
        }

        // POST: BasicDemoClasses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "myPk,name1,randomeDate")] BasicDemoClass basicDemoClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(basicDemoClass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(basicDemoClass);
        }

        // GET: BasicDemoClasses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BasicDemoClass basicDemoClass = db.BasicDemoClasses.Find(id);
            if (basicDemoClass == null)
            {
                return HttpNotFound();
            }
            return View(basicDemoClass);
        }

        // POST: BasicDemoClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BasicDemoClass basicDemoClass = db.BasicDemoClasses.Find(id);
            db.BasicDemoClasses.Remove(basicDemoClass);
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

        // MY MODIFICATIONS

        public ActionResult BOG_Index()
        {
            //This is a LINQ statment, it similar to a sql stament but for this project
            // For this page, I select only records  written by asdf but them into a list
            var linqDemo = (from e in db.BasicDemoClasses
                            where e.name1.Equals("asdf")
                            select e).ToList();
            //  can be replaced by anything
            // db is the entity created to access DB/Context (See line 15), 
            //basically the one created when first scafolded
            // The rest is pretty self explanatory

            //Here I am returning the list to my view
            return View(linqDemo);
        }



    }
}
