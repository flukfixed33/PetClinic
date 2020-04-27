using PetClinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.WebPages;

namespace PetClinic.Controllers
{
    public class HomeController : Controller
    {
        private PetClinicEntities db = new PetClinicEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            
            List<Table_Promote> imgPictures = db.Table_Promote.ToList();
            ViewBag.Images = imgPictures;
            ViewBag.Count = imgPictures.Count;
            return View(db.Table_Promote.ToList());
        }

        public ActionResult asdasdsadasd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult asdasdsadasd(string user, string pass)
        {
            if (user.IsEmpty() == false && pass.IsEmpty() == false)
            {
                var dataCk = db.AdminLogins.FirstOrDefault(x => x.Username == user && x.Password == pass);
                if(dataCk != null)
                {

                if (dataCk.Username.Equals(user) == true && dataCk.Password.Equals(pass) == true )
                {
                    Session["username"] = user;
                    if (dataCk != null && dataCk.Typeuser_ID == 1)
                    {
                        Session["type"] = "doc";
                        return RedirectToAction("Index", "Home");
                    }
                    return RedirectToAction("Index");
                }
                }
                
                return View();
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Contact", "Home");
        }

        [HttpGet]
        public ActionResult showdetails(int id)
        {
            var vm = new Table_Promote();

            var question = db.Table_Promote.FirstOrDefault(a => a.Promote_ID == id);
            if (question != null)
            {
                vm = question;
            }

            return PartialView( vm);
        }
        public ActionResult start()
        {
            return View();
        }

    }
}