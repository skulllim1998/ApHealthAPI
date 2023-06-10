using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApHealthAPI2.Request
{
    public class AddAppointmentRequest
    {
        public string Date { get; set; }
        public string Time { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
    }
}
