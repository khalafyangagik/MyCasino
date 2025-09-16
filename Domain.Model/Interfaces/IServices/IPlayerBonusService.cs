using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Casino.Core.Models;

namespace Casino.Core.Interfaces.IServices
{

    public interface IPlayerBonusService
    {
        Task AssignBonusToPlayerAsync(int playerId, int bonusId);
        Task<IEnumerable<Bonus>> GetPlayerBonusesAsync(int playerId);
        Task<IEnumerable<Player>> GetBonusPlayersAsync(int bonusId);
        Task UseBonusAsync(int playerId, int bonusId);
    }
}
