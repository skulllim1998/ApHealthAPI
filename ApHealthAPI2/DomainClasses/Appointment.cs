using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApHealthAPI2.DomainClasses;

namespace ApHealthAPI2.DomainClasses
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
    }
}
