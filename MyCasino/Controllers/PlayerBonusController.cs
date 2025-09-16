using Casino.Core.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace MyCasino.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerBonusController : ControllerBase
    {
        private readonly IPlayerBonusService _playerBonusService;

        public PlayerBonusController(IPlayerBonusService playerBonusService)
        {
            _playerBonusService = playerBonusService;
        }

        [HttpPost("assign")]
        public async Task<IActionResult> AssignBonus(int playerId, int bonusId)
        {
            await _playerBonusService.AssignBonusToPlayerAsync(playerId, bonusId);
            return Ok("Bonus assigned to player");
        }

        [HttpGet("player/{playerId}")]
        public async Task<IActionResult> GetPlayerBonuses(int playerId)
        {
            var bonuses = await _playerBonusService.GetPlayerBonusesAsync(playerId);
            return Ok(bonuses);
        }

        [HttpGet("bonus/{bonusId}")]
        public async Task<IActionResult> GetBonusPlayers(int bonusId)
        {
            var players = await _playerBonusService.GetBonusPlayersAsync(bonusId);
            return Ok(players);
        }

        [HttpPost("use")]
        public async Task<IActionResult> UseBonus(int playerId, int bonusId)
        {
            await _playerBonusService.UseBonusAsync(playerId, bonusId);
            return Ok("Bonus used");
        }
    }

}
