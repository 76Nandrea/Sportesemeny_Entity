using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedDTO;
using Mapster;
using SportBackend.DAL.Data;
using Microsoft.EntityFrameworkCore;
using SportBackend.DAL.Model;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace SportBackend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SportController : ControllerBase
    {
        private readonly MySQLDBContext _dbContext;
        public SportController(MySQLDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("Team")]
        public async Task<ActionResult<List<TeamDTO>>> GetAllTeam()
        {
            var team = await _dbContext.Team.ToListAsync();
            return Ok(team);
        }

        [HttpGet("Event")]
        public async Task<ActionResult<List<EventDTO>>> GetAllEvent()
        {
            var events = await _dbContext.Event
               .Include(e => e.Teams)
               .Select(e => new EventDTO
               {
                EventId = e.EventId,
                EventDate = e.EventDate,
                EventName = e.EventName,
                Teams = e.Teams.Select(t=>t.TeamName).ToList(),
               })
               .ToListAsync();
            return Ok(events);      
        }

        [HttpGet("Player")]
        public async Task<ActionResult<List<PlayerDTO>>> GetAllPlayer()
        {
            var player = await _dbContext.Player
                .Include(x => x.Team)
                .Select(p => new PlayerDTO
                { PlayerId = p.PlayerId,
                    FullName = p.FullName,
                    DateofBirth = p.DateofBirth,
                    Position = p.Position,
                    TeamName = p.Team.TeamName,
                    TeamId = p.TeamId,
                })
                .OrderBy(x => x.FullName)
                .ToListAsync();
            return Ok(player);
        }


        [HttpPost("AddPlayer")]
        public async Task<ActionResult<List<PlayerDTO>>> AddPlayer([FromBody] PlayerDTO playerdto)
        {
            var player = playerdto.Adapt<Player>();
            _dbContext.Player.Add(player);
            await _dbContext.SaveChangesAsync();

            var players = await _dbContext.Player
                    .Include(p => p.Team)
                    .ToListAsync();

            var playerDtos = players.Adapt<List<PlayerDTO>>();
            return Ok(playerDtos);
        }




        [HttpDelete("DeletePlayer/{PlayerId}")]
        public async Task<ActionResult<List<Player>>> DeletePlayer(int PlayerId)
        {
            var deletePlayer = await _dbContext.Player.FindAsync(PlayerId);
            if (deletePlayer == null)
            {
                return NotFound("Nincs ilyen Játékos");
             }
            _dbContext.Player.Remove(deletePlayer);
            await _dbContext.SaveChangesAsync();
            return Ok(await _dbContext.Player.ToListAsync());
        }

    }
}
