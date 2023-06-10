using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApHealthAPI2.Request
{
    public class AddDoctorRequest
    {
        public string DName { get; set; }
        public int Experience { get; set; }
        public int NumPatient { get; set; }
        public string DocLocation { get; set; }
        public string About { get; set; }
        public string DImage { get; set; }
        public int SpecialistId { get; set; }
    }
}
