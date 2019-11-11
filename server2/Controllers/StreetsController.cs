using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server2.Models;

namespace server2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StreetsController : ControllerBase
    {
        private readonly monopolisContext _context;

        public StreetsController(monopolisContext context)
        {
            _context = context;
        }

        // GET: api/Streets
        [HttpGet]
        public IEnumerable<Street> GetStreets()
        {
            return _context.Street;
        }

        // GET: api/Streets/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStreet([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var street = await _context.Street.FindAsync(id);

            if (street == null)
            {
                return NotFound();
            }

            return Ok(street);
        }



        public Street GetStreetByNum(int pos)
        {
           

            var streett = _context.Street.First(st => st.Number == pos);

            return streett;
        }




        // PUT: api/Streets/5
        [HttpPut("DeleteStreetsTags")]
        public async Task<IActionResult> PutStreet([FromRoute] int id, [FromBody] Street street)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            foreach (var entity in _context.Street)
                entity.FkPlayeridPlayer = null;
  
            await _context.SaveChangesAsync();

            return Ok();
        }



        [HttpPut("AssignStreet")]
        public async Task<IActionResult> AssignStreet([FromBody] Street street)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var streett = _context.Street.First(st => st.Number == street.Number);
            streett.FkPlayeridPlayer = street.FkPlayeridPlayer;


            await _context.SaveChangesAsync();


            return Ok();
        }





        // POST: api/Streets
        [HttpPost]
        public async Task<IActionResult> PostStreet([FromBody] Street street)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Street.Add(street);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStreet", new { id = street.IdStreets }, street);
        }

        // DELETE: api/Streets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStreet([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var street = await _context.Street.FindAsync(id);
            if (street == null)
            {
                return NotFound();
            }

            _context.Street.Remove(street);
            await _context.SaveChangesAsync();

            return Ok(street);
        }

        private bool StreetExists(int id)
        {
            return _context.Street.Any(e => e.IdStreets == id);
        }
    }
}