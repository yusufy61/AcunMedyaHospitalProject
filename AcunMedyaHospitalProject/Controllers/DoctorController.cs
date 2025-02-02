using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaHospitalProject.Context;
using AcunMedyaHospitalProject.Entities;
using AcunMedyaHospitalProject.Helpers;

namespace AcunMedyaHospitalProject.Controllers
{
    [Authorize]
    public class DoctorController : Controller
    {
        // GET: Doctor
        private readonly AppDbContext db = new AppDbContext();

        public ActionResult Index()
        {
            var doctors = db.Doctors.ToList();
            return View(doctors);
        }

        public ActionResult DoctorByDepartment(int id)
        {
            var doctors = db.Doctors.Where(x => x.DepartmentId == id).ToList();
            return View("Index", doctors);
        }

        [HttpGet]
        public ActionResult CreateDoctor()
        {
            TempData["Departments"] = DepartmentHelper.GetDepartments();
            return View();
        }

        [HttpPost]
        public ActionResult CreateDoctor(Doctor doctor)
        {
            if (!ModelState.IsValid)
            {
                TempData["Departments"] = DepartmentHelper.GetDepartments();
                return View();
            }
            else
            {
                db.Doctors.Add(doctor);
                db.SaveChanges();
                return RedirectToAction("Index", "Doctor");
            }

        }

        [HttpGet]
        public ActionResult DeleteDoctor(int id)
        {
            var doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            db.Doctors.Remove(doctor);
            db.SaveChanges();
            return RedirectToAction("Index", "Doctor");
        }

        [HttpGet]
        public ActionResult UpdateDoctor(int id)
        {
            var doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            TempData["Departments"] = DepartmentHelper.GetDepartments();
            return View(doctor);
        }

        [HttpPost]
        public ActionResult UpdateDoctor(Doctor doctor)
        {
            var updatedDoctor = db.Doctors.Find(doctor.Id);
            if (updatedDoctor == null)
            {
                return HttpNotFound();
            }
            updatedDoctor.FirstName = doctor.FirstName;
            updatedDoctor.LastName = doctor.LastName;
            updatedDoctor.ImageUrl = doctor.ImageUrl;
            updatedDoctor.DepartmentId = doctor.DepartmentId;
            db.SaveChanges();
            return RedirectToAction("Index", "Doctor");
        }
    }
}