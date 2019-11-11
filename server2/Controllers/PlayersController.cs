using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server2.Controllers;

namespace server2.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly monopolisContext _context;
        private IEnumerable<Street> streets;
        private static PlayersController instance = null;
        private static readonly object threadLock = new object(); // lock token
        public PlayersController(monopolisContext context)
        {
            _context = context;
            StreetsController strcntrl = new StreetsController(_context);
            streets = strcntrl.GetStreets();
        }
        public static PlayersController getInstance(monopolisContext context)
        {
            lock (threadLock)
            {
                if (instance == null)
                {
                    instance = new PlayersController(context);
                }
            }
            return instance;
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
            foreach (Street str in streets)
            {
                str.Attach(player);
            }
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


        [HttpPut("action/{act}")]
        public async Task<IActionResult> Act([FromRoute] int act,[FromBody] Player player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

       
            
            
            var playee = _context.Player.First(pl => pl.IndexP == player.IndexP);

             playee.Act(act, player, _context);


            //playee.Turn = player.Turn;

            await _context.SaveChangesAsync();


            return Ok();
        }



        [HttpDelete("deleteAll")]
        public async Task<IActionResult> DeleteAllPlayers()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            foreach (var entity in _context.Player)
                _context.Player.Remove(entity);
            // _context.SaveChanges();


            //    _context.Player.Remove(player);
            await _context.SaveChangesAsync();

            return Ok();
        }












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
        
    

        private bool PlayerExists(int id)
        {
            return _context.Player.Any(e => e.IdPlayer == id);
        }
    }
}