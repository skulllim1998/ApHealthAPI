using ApHealthAPI2.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApHealthAPI2.DomainClasses;
using ApHealthAPI2.Request;

namespace ApHealthAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialistController : ControllerBase
    {
        private readonly AppointmentContext _context;

        public SpecialistController(AppointmentContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetSpecialists()
        {
            return Ok(await _context.Specialists.ToListAsync());
        }

        //read specailist by id
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetSpecailistId([FromRoute] int id)
        {
            var specialist = await _context.Specialists.FindAsync(id);

            if (specialist == null)
            {
                return NotFound();
            }

            return Ok(specialist);
        }

        //create specialist
        [HttpPost]
        public async Task<IActionResult> AddDoctor(AddSpecialistRequest addSpecialistRequest)
        {
            var specialist = new Specialist()
            {
                SName = addSpecialistRequest.SName,
                SImage = addSpecialistRequest.SImage
            };

            await _context.Specialists.AddAsync(specialist);
            await _context.SaveChangesAsync();
            return Ok(specialist);
        }

        //update specialist
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateSpecialist([FromRoute] int id, UpdateSpecialistRequest updateSpecialistRequest)
        {
            var specialist = await _context.Specialists.FindAsync(id);

            if (specialist != null)
            {
                specialist.SName = updateSpecialistRequest.SName;
                specialist.SImage = updateSpecialistRequest.SImage;

                await _context.SaveChangesAsync();
                return Ok(specialist);
            }

            return NotFound();
        }

        //delete specialist
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteSpecialist([FromRoute] int id)
        {
            var specialist = await _context.Specialists.FindAsync(id);

            if (specialist != null)
            {
                _context.Remove(specialist);
                await _context.SaveChangesAsync();
                return Ok(specialist);
            }

            return NotFound();
        }

    }
}
