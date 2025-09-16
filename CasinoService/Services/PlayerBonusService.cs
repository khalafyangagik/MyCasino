using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Casino.Core.Interfaces.IRepositories;
using Casino.Core.Interfaces.IServices;
using Casino.Core.Models;

namespace CasinoService.Services
{
    public class PlayerBonusService : IPlayerBonusService
    {
        private readonly IPlayerBonusRepository _playerBonusRepository;

        public PlayerBonusService(IPlayerBonusRepository playerBonusRepository)
        {
            _playerBonusRepository = playerBonusRepository;
        }

        public async Task AssignBonusToPlayerAsync(int playerId, int bonusId)
        {
            await _playerBonusRepository.AssignBonusAsync(playerId, bonusId);
        }

        public async Task<IEnumerable<Bonus>> GetPlayerBonusesAsync(int playerId)
        {
            return await _playerBonusRepository.GetBonusesForPlayerAsync(playerId);
        }

        public async Task<IEnumerable<Player>> GetBonusPlayersAsync(int bonusId)
        {
            return await _playerBonusRepository.GetPlayersForBonusAsync(bonusId);
        }

        public async Task UseBonusAsync(int playerId, int bonusId)
        {
            await _playerBonusRepository.MarkBonusAsUsedAsync(playerId, bonusId);
        }
    }

}
