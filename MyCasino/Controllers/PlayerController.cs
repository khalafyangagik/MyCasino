using System;
using Casino.Core.Interfaces.IServices;
using Casino.Core.Models;
using CasinoService.Services;
using Data.DbContextFile;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;

namespace MyCasino.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly IUserService _userService;

        public PlayerController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerDto>>> GetPlayers()
        {
            var players = await _userService.GetPlayers();
            var dto = players.Select(p => new PlayerDto
            {
                Id = p.Id,
                Username = p.Username,
                Age = p.Age
            });
            return Ok(dto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerDto>> GetPlayer(int id)
        {
            var player = await _userService.GetPlayer(id);
            var dto = new PlayerDto
            {
                Id = player.Id,
                Username = player.Username,
                Age = player.Age
            };
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<PlayerDto>> AddPlayer([FromBody] PlayerDto playerDto)
        {
            var player = new Player(playerDto.Username, playerDto.Age);
            var created = await _userService.AddPlayer(player);

            var dto = new PlayerDto
            {
                Id = created.Id,
                Username = created.Username,
                Age = created.Age
            };
            return CreatedAtAction(nameof(GetPlayer), new { id = dto.Id }, dto);
        }
    }

}
