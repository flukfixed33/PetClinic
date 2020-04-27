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
    public class Table_TypePetController : Controller
    {
        private PetClinicEntities db = new PetClinicEntities();

        // GET: Table_TypePet
        public ActionResult Index()
        {
            return View(db.Table_TypePet.ToList());
        }

        // GET: Table_TypePet/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_TypePet table_TypePet = db.Table_TypePet.Find(id);
            if (table_TypePet == null)
            {
                return HttpNotFound();
            }
            return View(table_TypePet);
        }

        // GET: Table_TypePet/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Table_TypePet/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Type_ID,TypeName")] Table_TypePet table_TypePet)
        {
            if (ModelState.IsValid)
            {
                db.Table_TypePet.Add(table_TypePet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(table_TypePet);
        }

        // GET: Table_TypePet/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_TypePet table_TypePet = db.Table_TypePet.Find(id);
            if (table_TypePet == null)
            {
                return HttpNotFound();
            }
            return View(table_TypePet);
        }

        // POST: Table_TypePet/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Type_ID,TypeName")] Table_TypePet table_TypePet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(table_TypePet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(table_TypePet);
        }

        // GET: Table_TypePet/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Table_TypePet table_TypePet = db.Table_TypePet.Find(id);
                if (table_TypePet == null)
                {
                    return HttpNotFound();
                }
                db.Table_TypePet.Remove(table_TypePet);
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
