using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Casino.Core.Models;

namespace Casino.Core.Interfaces.IRepositories
{
    public interface IPlayerBonusRepository
    {
        Task AssignBonusAsync(int playerId, int bonusId);
        Task<IEnumerable<Bonus>> GetBonusesForPlayerAsync(int playerId);
        Task<IEnumerable<Player>> GetPlayersForBonusAsync(int bonusId);
        Task MarkBonusAsUsedAsync(int playerId, int bonusId);
    }
}
