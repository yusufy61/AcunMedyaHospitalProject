using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AcunMedyaHospitalProject.Context;
using AcunMedyaHospitalProject.Entities;

namespace AcunMedyaHospitalProject.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        AppDbContext db = new AppDbContext();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            var adminUser = db.Admins.FirstOrDefault(x => x.UserName == admin.UserName && x.Password == admin.Password);
            if(adminUser == null)
            {
                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı!");
                return View();
            }
            FormsAuthentication.SetAuthCookie(adminUser.UserName, true); // daha sonradan kullanacaksan veriler hazır olarak bulunsun diye true olarka işaretledik yoksa false olarak işaretliyrouz.
            return RedirectToAction("Index","Doctor");
        }
    }
}