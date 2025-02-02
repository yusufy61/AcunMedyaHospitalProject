using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AcunMedyaHospitalProject.Enums;

namespace AcunMedyaHospitalProject.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan Time { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
        public string PatientPhone { get; set; }
        public string PatientEmail { get; set; }
        public AppointmentStatus Status { get; set; }
        //status 0 ise pending , 1 ise approved, 2 ise cancelled, bu değerler default olarak verilir
        public virtual Doctor Doctor { get; set; }

    }
}