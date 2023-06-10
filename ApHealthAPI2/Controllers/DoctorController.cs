using ApHealthAPI2.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApHealthAPI2.DomainClasses;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.Application;
using ApHealthAPI2.Request;

namespace ApHealthAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly AppointmentContext _context;

        public DoctorController(AppointmentContext context)
        {
            _context = context;
        }

        //read all doctor
        [HttpGet]
        public async Task<IActionResult> GetDoctors()
        {
            return Ok(await _context.Doctors.ToListAsync());
        }

        //read doctor by id
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetDoctorId([FromRoute] int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);

            if (doctor == null)
            {
                return NotFound();
            }

            return Ok(doctor);
        }

        [HttpGet]
        [Route("filter/{id}")]
        public async Task<IActionResult> GetDoctorBySpecialistId([FromRoute] int id)
        {

            var doctor = await _context.Doctors
                                .Where(doctor => doctor.SpecialistId == id)
                                .ToListAsync();

            if (doctor == null)
            {
                return NotFound();
            }

            return Ok(doctor);
        }

        //create doctor
        [HttpPost]
        public async Task<IActionResult> AddDoctor(AddDoctorRequest addDoctorRequest)
        {
            var doctor = new Doctor()
            {
                DName = addDoctorRequest.DName,
                Experience = addDoctorRequest.Experience,
                NumPatient = addDoctorRequest.NumPatient,
                DocLocation = addDoctorRequest.DocLocation,
                About = addDoctorRequest.About,
                DImage = addDoctorRequest.DImage,
                SpecialistId = addDoctorRequest.SpecialistId
            };

            await _context.Doctors.AddAsync(doctor);
            await _context.SaveChangesAsync();
            return Ok(doctor);
        }

        //update doctor
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateDoctor([FromRoute] int id, UpdateDoctorRequest updateDoctorRequest)
        {
            var doctor = await _context.Doctors.FindAsync(id);

            if (doctor != null)
            {
                doctor.DName = updateDoctorRequest.DName;
                doctor.Experience = updateDoctorRequest.Experience;
                doctor.NumPatient = updateDoctorRequest.NumPatient;
                doctor.DocLocation = updateDoctorRequest.DocLocation;
                doctor.About = updateDoctorRequest.About;
                doctor.DImage = updateDoctorRequest.DImage;
                doctor.SpecialistId = updateDoctorRequest.SpecialistId;

                await _context.SaveChangesAsync();
                return Ok(doctor);
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteDoctor([FromRoute] int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);

            if (doctor != null)
            {
                _context.Remove(doctor);
                await _context.SaveChangesAsync();
                return Ok(doctor);
            }

            return NotFound();
        }

    }
}
