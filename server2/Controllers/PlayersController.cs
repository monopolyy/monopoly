using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace server2.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly monopolisContext _context;

        public PlayersController(monopolisContext context)
        {
            _context = context;
        }

        // GET: api/Players
        [HttpGet]
        public IEnumerable<Player> GetPlayer()
       {
            return _context.Player;
        }

        // GET: api/Players/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlayer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var player = await _context.Player.FindAsync(id);

            if (player == null)
            {
                return NotFound();
            }

            return Ok(player);
        }

        // PUT: api/Players/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayer([FromRoute] int id, [FromBody] Player player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != player.IdPlayer)
            {
                return BadRequest();
            }

            _context.Entry(player).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        
        [HttpPut("endTurn")]
        public async Task<IActionResult> EndPlayerTurn([FromBody] Player player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var playee = _context.Player.First(pl => pl.IndexP == player.IndexP);
            playee.Turn = player.Turn;

            await _context.SaveChangesAsync();

              try
              {
                  await _context.SaveChangesAsync();
              }
              catch (DbUpdateConcurrencyException)
              {
                  if (!PlayerExists(player.IdPlayer))
                  {
                      return NotFound();
                  }
                  else
                  {
                      throw;
                  }
              }

            return Ok();
        }


        [HttpPut("move")]
        public async Task<IActionResult> MovePlayer([FromBody] Player player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var playee = _context.Player.First(pl => pl.IndexP == player.IndexP);
            playee.CurrentPosition = player.CurrentPosition;

            await _context.SaveChangesAsync();

          

              try
              {
                  await _context.SaveChangesAsync();
              }
              catch (DbUpdateConcurrencyException)
              {
                  if (!PlayerExists(player.IdPlayer))
                  {
                      return NotFound();
                  }
                  else
                  {
                      throw;
                  }
              }

            return Ok();
        }


        // POST: api/Players
        [HttpPost("new")]
        public async Task<IActionResult> PostPlayer([FromBody] Player player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Player.Add(player);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlayer", new { id = player.IdPlayer }, player);
        }

        // DELETE: api/Players/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var player = await _context.Player.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }

            _context.Player.Remove(player);
            await _context.SaveChangesAsync();

            return Ok(player);
        }

        private bool PlayerExists(int id)
        {
            return _context.Player.Any(e => e.IdPlayer == id);
        }
    }
}