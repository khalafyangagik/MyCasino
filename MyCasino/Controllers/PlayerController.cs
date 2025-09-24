using System;
using Casino.Core.Interfaces.IServices;
using Casino.Core.Models;
using CasinoService.Services;
using Data.DbContextFile;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;
using Casino.Core.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace MyCasino.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;


        public PlayerController(IUserService userService,IMapper mapper)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
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
          var player = _mapper.Map<Player>(playerDto);
          var created = await _userService.AddPlayer(player);
          var dto = _mapper.Map<PlayerDto>(created);
          return CreatedAtAction(nameof(GetPlayer), new { id = dto.Id }, dto);
        }

        [HttpGet("Rich")]
        public async Task<IActionResult> GetRichPlayers()
        {
            var players = await _userService.GetRichPlayers();
            return Ok(players);
        }

        [HttpDelete]

        public async Task<IActionResult> Delete(int id)
        {
            await _userService.Delete(id);
            return Ok();
        }
    }

}
