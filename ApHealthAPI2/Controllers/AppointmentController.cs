using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApHealthAPI2.Data;
using ApHealthAPI2.DomainClasses;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.Application;
using ApHealthAPI2.Request;

namespace ApHealthAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly AppointmentContext _context;

        public AppointmentController(AppointmentContext context)
        {
            _context = context;
        }

        //read all appointment
        [HttpGet]
        public async Task<IActionResult> GetAppointments()
        {
            return Ok(await _context.Appointments.ToListAsync());
        }

        //read appointment by id
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetAppointmentByPatientId([FromRoute] int id)
        {

            var appointment = await _context.Appointments
                                .Where(appointment => appointment.PatientId == id)
                                .ToListAsync();

            if (appointment == null)
            {
                return NotFound();
            }

            return Ok(appointment);
        }


        //create appointment
        [HttpPost]
        public async Task<IActionResult> AddAppointment(AddAppointmentRequest addAppointmentRequest)
        {
            var appointment = new Appointment()
            {
                Date = addAppointmentRequest.Date,
                Time = addAppointmentRequest.Time,
                PatientId = addAppointmentRequest.PatientId,
                DoctorId = addAppointmentRequest.DoctorId
            };

            await _context.Appointments.AddAsync(appointment);
            await _context.SaveChangesAsync();
            return Ok(appointment);
        }

        //update appointment
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateAppointment([FromRoute] int id, UpdateAppointmentRequest updateAppointmentRequest)
        {
            var appointment = await _context.Appointments.FindAsync(id);

            if (appointment != null)
            {
                appointment.Date = updateAppointmentRequest.Date;
                appointment.Time = updateAppointmentRequest.Time;
                appointment.PatientId = updateAppointmentRequest.PatientId;
                appointment.DoctorId = updateAppointmentRequest.DoctorId;

                await _context.SaveChangesAsync();
                return Ok(appointment);
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteAppointment([FromRoute] int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);

            if (appointment != null)
            {
                _context.Remove(appointment);
                await _context.SaveChangesAsync();
                return Ok(appointment);
            }

            return NotFound();
        }

    }
}
