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
    public class Table_OwnerController : Controller
    {
        private PetClinicEntities db = new PetClinicEntities();

        // GET: Table_Owner
        public ActionResult Index()
        {
            return View(db.Table_Owner.ToList());
        }

        // GET: Table_Owner/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_Owner table_Owner = db.Table_Owner.Find(id);
            if (table_Owner == null)
            {
                return HttpNotFound();
            }
            return View(table_Owner);
        }

        // GET: Table_Owner/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Table_Owner/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Table_Owner table_Owner)
        {
            if (ModelState.IsValid)
            {
                db.Table_Owner.Add(table_Owner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(table_Owner);
        }

        // GET: Table_Owner/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_Owner table_Owner = db.Table_Owner.Find(id);
            if (table_Owner == null)
            {
                return HttpNotFound();
            }
            return View(table_Owner);
        }

        // POST: Table_Owner/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Owner_ID,Firstname,Lastname,Address,Telephone")] Table_Owner table_Owner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(table_Owner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(table_Owner);
        }

        // GET: Table_Owner/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Table_Owner table_Owner = db.Table_Owner.Find(id);
                if (table_Owner == null)
                {
                    return HttpNotFound();
                }
                db.Table_Owner.Remove(table_Owner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                
                return RedirectToAction("Index");
            }
            
        }
    }
}
