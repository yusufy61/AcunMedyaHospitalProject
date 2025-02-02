using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaHospitalProject.Context;

namespace AcunMedyaHospitalProject.Helpers
{
    public static class DepartmentHelper
    {
        // readonly: sadece okunabilir demektir. Değer ataması yapılamaz.
        // static : static fonksiyonun içinde oldluğumuza göre static bir değişken tanımlamamız gerekiyor.
        private readonly static AppDbContext db = new AppDbContext();
        public static SelectList GetDepartments()
        {
            var departments = db.Departments.ToList();
            return new SelectList(departments, "Id", "Name");
        }

        public static SelectList GetDepartments(int selectedValue)
        {
            var departments = db.Departments.ToList();
            return new SelectList(departments, "Id", "Name",selectedValue);
        }
    }
}