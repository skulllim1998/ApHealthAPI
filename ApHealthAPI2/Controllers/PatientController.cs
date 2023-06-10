using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApHealthAPI2.Data;
using Microsoft.EntityFrameworkCore;
using ApHealthAPI2.DomainClasses;
using ApHealthAPI2.Request;
using Microsoft.AspNetCore.Authorization;

namespace ApHealthAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly AppointmentContext _context;

        public PatientController(AppointmentContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetPatients()
        {
            return Ok(await _context.Patients.ToListAsync());
        }

        //read patient by id
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetPatientId([FromRoute] int id)
        {
            var patient = await _context.Patients.FindAsync(id);

            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }

        [HttpPost]
        [Route("getpatient")]
        public async Task<IActionResult> GetPatient(GetPatientRequest getPatientRequest)
        {
            var patient = await _context.Patients
                                .Where(patient => 
                                patient.Email == getPatientRequest.Email && patient.Password == getPatientRequest.Password)
                                .FirstOrDefaultAsync();

            //patient.Password = null;

            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }

        //create patient
        [HttpPost]
        public async Task<IActionResult> AddPatient(AddPatientRequest addPatientRequest)
        {
            var patient = new Patient()
            {
                Email = addPatientRequest.Email,
                Password = addPatientRequest.Password,
                PName = addPatientRequest.PName,
                Phone = addPatientRequest.Phone,
                Address = addPatientRequest.Address
            };

            await _context.Patients.AddAsync(patient);
            await _context.SaveChangesAsync();
            return Ok(patient);
        }

        //update patient
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdatePatient([FromRoute] int id, UpdatePatientRequest updatePatientRequest)
        {
            var patient = await _context.Patients.FindAsync(id);

            if (patient != null)
            {
                patient.Password = updatePatientRequest.Password;
                patient.PName = updatePatientRequest.PName;
                patient.Phone = updatePatientRequest.Phone;
                patient.Address = updatePatientRequest.Address;

                await _context.SaveChangesAsync();
                return Ok(patient);
            }

            return NotFound();
        }

        //delete patient
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeletePatient([FromRoute] int id)
        {
            var patient = await _context.Patients.FindAsync(id);

            if (patient != null)
            {
                _context.Remove(patient);
                await _context.SaveChangesAsync();
                return Ok(patient);
            }

            return NotFound();
        }

    }
}
