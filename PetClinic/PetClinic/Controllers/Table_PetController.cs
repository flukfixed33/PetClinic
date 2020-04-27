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
    public class Table_PetController : Controller
    {
        private PetClinicEntities db = new PetClinicEntities();

        public ActionResult Index()
        {
            ViewBag.Title = "จัดการข้อมูลสัตว์เลี้ยง";
            var table_Pet = db.Table_Pet.Include(t => t.Table_Owner).Include(t => t.Table_TypePet);
            return View(table_Pet.ToList());

        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_Pet table_Pet = db.Table_Pet.Find(id);
            if (table_Pet == null)
            {
                return HttpNotFound();
            }
            return View(table_Pet);
        }


        public ActionResult AddVisitToPet(int id)
        {
            ViewBag.Pet_ID = new SelectList(db.Table_Pet, "Pet_ID", "Pet_Name", id);
            return View(new Table_Visit { Pet_ID = id });
        }
        [HttpPost]
        public ActionResult AddVisitToPet(Table_Visit table_Visit)
        {
            if (ModelState.IsValid)
            {
                db.Table_Visit.Add(table_Visit);
                table_Visit.VisitDate = DateTime.UtcNow;
                db.SaveChanges();
                return RedirectToAction("Index", "Table_Visit");
            }

            ViewBag.Pet_ID = new SelectList(db.Table_Pet, "Pet_ID", "Pet_Name", table_Visit.Pet_ID);
            return View(table_Visit);
        }
        [HttpPost]
        public ActionResult CreatV(Table_Visit data)
        {
            if (ModelState.IsValid)
            {
                db.Table_Visit.Add(data);
                db.SaveChanges();
            }

            return View(data);
        }

       
       
        public ActionResult Create()
        {
            List<Table_Owner> test = new List<Table_Owner>();
            foreach (var item in db.Table_Owner)
            {
                test.Add(new Table_Owner
                {
                    Owner_ID = item.Owner_ID,
                    Firstname = item.Firstname + "  " + item.Lastname
                });

            }
            ViewBag.Owner_ID = new SelectList(test.ToList(), "Owner_ID", "Firstname"); 
            ViewBag.Type_ID = new SelectList(db.Table_TypePet, "Type_ID", "TypeName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Table_Pet table_Pet)
        {
            ViewBag.Owner_ID = new SelectList(db.Table_Owner, "Owner_ID", "Firstname", table_Pet.Owner_ID);
            if (ModelState.IsValid)
            {

                if (table_Pet.Age == null)
                {
                    table_Pet.Age = DateTime.UtcNow;
                }
                db.Table_Pet.Add(table_Pet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Type_ID = new SelectList(db.Table_TypePet, "Type_ID", "TypeName", table_Pet.Type_ID);
            return View(table_Pet);
        }

        // GET: Table_Pet/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_Pet table_Pet = db.Table_Pet.Find(id);

            if (table_Pet == null)
            {
                return HttpNotFound();
            }
            ViewBag.Owner_ID = new SelectList(db.Table_Owner, "Owner_ID", "Firstname", table_Pet.Owner_ID);
            ViewBag.Type_ID = new SelectList(db.Table_TypePet, "Type_ID", "TypeName", table_Pet.Type_ID);
            return View(table_Pet);
        }

        // POST: Table_Pet/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Table_Pet table_Pet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(table_Pet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Owner_ID = new SelectList(db.Table_Owner, "Owner_ID", "Firstname", table_Pet.Owner_ID);
            ViewBag.Type_ID = new SelectList(db.Table_TypePet, "Type_ID", "TypeName", table_Pet.Type_ID);
            return View(table_Pet);
        }

        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Table_Pet table_Pet = db.Table_Pet.Find(id);
                if (table_Pet == null)
                {
                    return HttpNotFound();
                }
                db.Table_Pet.Remove(table_Pet);
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
