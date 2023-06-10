using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApHealthAPI2.Request
{
    public class UpdatePatientRequest
    {
        public string Password { get; set; }
        public string PName { get; set; }
        public int Phone { get; set; }
        public string Address { get; set; }
    }
}
