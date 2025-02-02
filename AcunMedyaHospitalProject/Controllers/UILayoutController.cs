using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcunMedyaHospitalProject.Controllers
{
    public class UILayoutController : Controller
    {
        // GET: UILayout
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PartialHeader()
        {
            return PartialView();
        }

        public ActionResult PartialSiteHeader()
        {
            return PartialView();
        }

        public ActionResult PartialFooter()
        {
            return PartialView();
        }

        public ActionResult PartialAppointment()
        {
            return PartialView();
        }

        public ActionResult PartialScripts()
        {
            return PartialView();
        }
    }
}