using Casino.Core.Interfaces.IServices;
using Casino.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;  

namespace MyCasino.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class BetController : ControllerBase
    {
        private readonly IBetService _betService;

        public BetController(IBetService betService)
        {
            _betService = betService;
        }

        [HttpPost("place")]
        public async Task<ActionResult<BetDto>> PlaceBet([FromQuery] string gameName, [FromQuery] int playerId, [FromQuery] decimal amount)
        {
            if (amount <= 0)
                return BadRequest("Amount must be > 0");

            var bet = await _betService.PlaceBetAsync(gameName, playerId, amount);

            var dto = new BetDto
            {
                Id = bet.Id,
                PlayerId = bet.PlayerId,
                GameName = bet.GameName,
                Coeficent = bet.Coeficent,
                Result = bet.Result,
                IsWon = bet.isWon
            };

            return Ok(dto);
        }

        [HttpGet("user bets")]

        public async Task<ActionResult<IList<Bet>>> GetAllBet(int id)
        {
           var bets = await _betService.GetAllBets(id);
           return Ok(bets);
        }

     
    }

}