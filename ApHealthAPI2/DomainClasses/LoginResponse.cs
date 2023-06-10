using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApHealthAPI2.DomainClasses
{
    public class LoginResponse
    {
        public Boolean error { get; set; }
        public string message { get; set; }
        public Patient patient { get; set; }
    }
}
