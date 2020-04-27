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
    public class Table_TypeuserController : Controller
    {
        private PetClinicEntities db = new PetClinicEntities();

        // GET: Table_Typeuser
        public ActionResult Index()
        {
            return View(db.Table_Typeuser.ToList());
        }

        // GET: Table_Typeuser/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_Typeuser table_Typeuser = db.Table_Typeuser.Find(id);
            if (table_Typeuser == null)
            {
                return HttpNotFound();
            }
            return View(table_Typeuser);
        }

        // GET: Table_Typeuser/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Table_Typeuser/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Typeuser_ID,TypeuserName")] Table_Typeuser table_Typeuser)
        {
            if (ModelState.IsValid)
            {
                db.Table_Typeuser.Add(table_Typeuser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(table_Typeuser);
        }

        // GET: Table_Typeuser/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_Typeuser table_Typeuser = db.Table_Typeuser.Find(id);
            if (table_Typeuser == null)
            {
                return HttpNotFound();
            }
            return View(table_Typeuser);
        }

        // POST: Table_Typeuser/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Typeuser_ID,TypeuserName")] Table_Typeuser table_Typeuser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(table_Typeuser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(table_Typeuser);
        }

        // GET: Table_Typeuser/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Table_Typeuser table_Typeuser = db.Table_Typeuser.Find(id);
                if (table_Typeuser == null)
                {
                    return HttpNotFound();
                }
                db.Table_Typeuser.Remove(table_Typeuser);
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
