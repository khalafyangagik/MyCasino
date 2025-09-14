using Casino.Core.Interfaces.IServices;
using Casino.Core.Models;
using CasinoService.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;

namespace MyCasino.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WalletController : ControllerBase
    {
        private readonly IWalletService _walletService;

        public WalletController(IWalletService walletService)
        {
            _walletService = walletService;
        }

        [HttpGet("{playerId}")]
        public async Task<ActionResult<WalletDto>> GetWallet(int playerId)
        {
            var wallet = await _walletService.GetWallet(playerId);
            var dto = new WalletDto
            {
                Id = wallet.Id,
                PlayerId = wallet.PlayerId,
                Balance = wallet.Balance
            };
            return Ok(dto);
        }

        [HttpPost("topup/{playerId}")]
        public async Task<ActionResult<WalletDto>> TopUpWallet(int playerId, [FromQuery] decimal amount)
        {
            var balance = await _walletService.TopUpWallet(playerId, amount);
            var wallet = await _walletService.GetWallet(playerId);

            var dto = new WalletDto
            {
                Id = wallet.Id,
                PlayerId = wallet.PlayerId,
                Balance = wallet.Balance
            };
            return Ok(dto);
        }
    }

}
