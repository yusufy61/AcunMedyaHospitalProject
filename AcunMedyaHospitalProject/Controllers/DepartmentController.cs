using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaHospitalProject.Context;
using AcunMedyaHospitalProject.Entities;

namespace AcunMedyaHospitalProject.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        AppDbContext db = new AppDbContext();
        public ActionResult Index()
        {
            var departments = db.Departments.ToList();
            return View(departments);
        }

        public ActionResult CreateDepartment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateDepartment(Department department)
        {
            db.Departments.Add(department);
            db.SaveChanges();
            return RedirectToAction("Index", "Department");
        }

        [HttpGet]
        public ActionResult DeleteDepartment(int id)
        {
            var department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            db.Departments.Remove(department);
            db.SaveChanges();
            return RedirectToAction("Index", "Department");
        }

        [HttpGet]
        public ActionResult UpdateDepartment(int id)
        {
            var department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        [HttpPost]
        public ActionResult UpdateDepartment(Department department)
        {
            var updatedDepartment = db.Departments.Find(department.Id);
            if (updatedDepartment == null)
            {
                return HttpNotFound();
            }
            updatedDepartment.Name = department.Name;
            updatedDepartment.Description = department.Description;
            updatedDepartment.ImageUrl = department.ImageUrl;
            db.SaveChanges();
            return RedirectToAction("Index", "Department");
        }
    }
}