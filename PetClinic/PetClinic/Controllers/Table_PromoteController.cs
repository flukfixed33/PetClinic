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
    public class Table_PromoteController : Controller
    {
        private PetClinicEntities db = new PetClinicEntities();

        // GET: Table_Promote
        public ActionResult Index()
        {
            return View(db.Table_Promote.ToList());
        }

        // GET: Table_Promote/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_Promote table_Promote = db.Table_Promote.Find(id);
            if (table_Promote == null)
            {
                return HttpNotFound();
            }
            return View(table_Promote);
        }

        // GET: Table_Promote/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Table_Promote/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        public ActionResult Create(Table_Promote table_Promote, HttpPostedFileBase file)
        {

            if (file != null && file.ContentLength > 0)
            {
                var myUniqueFileName = DateTime.Now.Ticks + ".jpg";
                string physicalPath = Server.MapPath("~/img/" + myUniqueFileName);
                file.SaveAs(physicalPath);
                table_Promote.Promote_Pic = myUniqueFileName;

            }
            db.Table_Promote.Add(table_Promote);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Table_Promote/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_Promote table_Promote = db.Table_Promote.Find(id);
            if (table_Promote == null)
            {
                return HttpNotFound();
            }
            return View(table_Promote);
        }

        // POST: Table_Promote/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Table_Promote table_Promote, HttpPostedFileBase file)
        {
            try
            {
                var recordToUpdate = db.Table_Promote.AsNoTracking().Single(x => x.Promote_ID == table_Promote.Promote_ID);
                if (file != null && file.ContentLength > 0)
                {
                    var myUniqueFileName = DateTime.Now.Ticks + ".jpg";
                    string physicalPath = Server.MapPath("~/img/" + myUniqueFileName);
                    file.SaveAs(physicalPath);
                    table_Promote.Promote_Pic = myUniqueFileName;

                }
                else
                {
                    table_Promote.Promote_Pic = recordToUpdate.Promote_Pic;
                }
            }
            catch (Exception)
            {
                ViewBag.Message = "อัพเดทข้อมูลไม่สำเร็จ กรุณาตรวจสอบข้อมูลและลองใหม่อีกครั้ง";
            }


            db.Entry(table_Promote).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");

        }


        // GET: Table_Promote/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_Promote table_Promote = db.Table_Promote.Find(id);
            if (table_Promote == null)
            {
                return HttpNotFound();
            }
            db.Table_Promote.Remove(table_Promote);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}
