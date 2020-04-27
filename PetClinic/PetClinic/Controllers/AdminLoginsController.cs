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
    public class AdminLoginsController : Controller
    {
        private PetClinicEntities db = new PetClinicEntities();


        // GET: AdminLogins
        public ActionResult Index()
        {
            var adminLogins = db.AdminLogins.Include(a => a.Table_Typeuser);
            return View(adminLogins.ToList());
        }


        // GET: AdminLogins/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminLogin adminLogin = db.AdminLogins.Find(id);
            if (adminLogin == null)
            {
                return HttpNotFound();
            }
            return View(adminLogin);
        }

        // GET: AdminLogins/Create
        public ActionResult Create()
        {
            ViewBag.Typeuser_ID = new SelectList(db.Table_Typeuser, "Typeuser_ID", "TypeuserName");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Username,Password,Typeuser_ID")] AdminLogin adminLogin)
        {
            if (ModelState.IsValid)
            {
                db.AdminLogins.Add(adminLogin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Typeuser_ID = new SelectList(db.Table_Typeuser, "Typeuser_ID", "TypeuserName", adminLogin.Typeuser_ID);
            return View(adminLogin);
        }

        // GET: AdminLogins/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminLogin adminLogin = db.AdminLogins.Find(id);
            if (adminLogin == null)
            {
                return HttpNotFound();
            }
            ViewBag.Typeuser_ID = new SelectList(db.Table_Typeuser, "Typeuser_ID", "TypeuserName", adminLogin.Typeuser_ID);
            return View(adminLogin);
        }

        // POST: AdminLogins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Username,Password,Typeuser_ID")] AdminLogin adminLogin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adminLogin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Typeuser_ID = new SelectList(db.Table_Typeuser, "Typeuser_ID", "TypeuserName", adminLogin.Typeuser_ID);
            return View(adminLogin);
        }

        // GET: AdminLogins/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                AdminLogin adminLogin = db.AdminLogins.Find(id);
                if (adminLogin == null)
                {
                    return HttpNotFound();
                }
                db.AdminLogins.Remove(adminLogin);
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
