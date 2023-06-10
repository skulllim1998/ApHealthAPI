using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApHealthAPI2.Request
{
    public class GetPatientRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
