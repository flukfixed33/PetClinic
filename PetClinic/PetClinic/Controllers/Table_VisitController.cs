using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PetClinic.Models;

namespace PetClinic.Controllers
{
    public class Table_VisitController : Controller
    {
        private PetClinicEntities db = new PetClinicEntities();

        // GET: Table_Visit
        public ActionResult Index()
        {
            var table_Visit = db.Table_Visit.Include(t => t.Table_Pet);
            return View(table_Visit.ToList());
        }

        // GET: Table_Visit/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_Visit table_Visit = db.Table_Visit.Find(id);
            if (table_Visit == null)
            {
                return HttpNotFound();
            }
            return View(table_Visit);
        }

        // GET: Table_Visit/Create
        public ActionResult Create()
        {
            ViewBag.Pet_ID = new SelectList(db.Table_Pet, "Pet_ID", "Pet_Name");
            return View();
        }

        // POST: Table_Visit/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create( Table_Visit table_Visit)
        {
            if (ModelState.IsValid)
            {
                db.Table_Visit.Add(table_Visit);
                table_Visit.VisitDate = DateTime.UtcNow;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Pet_ID = new SelectList(db.Table_Pet, "Pet_ID", "Pet_Name", table_Visit.Pet_ID);
            return View(table_Visit);
        }

        // GET: Table_Visit/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_Visit table_Visit = db.Table_Visit.Find(id);
            if (table_Visit == null)
            {
                return HttpNotFound();
            }
            ViewBag.Pet_ID = new SelectList(db.Table_Pet, "Pet_ID", "Pet_Name", table_Visit.Pet_ID);
            return View(table_Visit);
        }

        // POST: Table_Visit/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Table_Visit table_Visit )
        {
            if (ModelState.IsValid)
            {
                db.Entry(table_Visit).State = EntityState.Modified;
                table_Visit.VisitDate = DateTime.UtcNow;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Pet_ID = new SelectList(db.Table_Pet, "Pet_ID", "Pet_Name", table_Visit.Pet_ID);
            return View(table_Visit);
        }

        // GET: Table_Visit/Delete/5
        public ActionResult Delete(int? id)
        {
            if(Session["type"] != null)
            {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_Visit table_visit = db.Table_Visit.Find(id);
            if (table_visit == null)
            {
                return HttpNotFound();
            }
            db.Table_Visit.Remove(table_visit);
            db.SaveChanges();
            return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

    }
}
