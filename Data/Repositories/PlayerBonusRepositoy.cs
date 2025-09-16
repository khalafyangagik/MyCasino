using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Casino.Core.Interfaces.IRepositories;
using Casino.Core.Models;
using Data.DbContextFile;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class PlayerBonusRepository : IPlayerBonusRepository
    {
        private readonly CasinoDbContext _context;

        public PlayerBonusRepository(CasinoDbContext context)
        {
            _context = context;
        }

        public async Task AssignBonusAsync(int playerId, int bonusId)
        {
            var playerBonus = new PlayerBonus
            {
                PlayerId = playerId,
                BonusId = bonusId,
                IsUsed = false
            };

            _context.PlayerBonuses.Add(playerBonus);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Bonus>> GetBonusesForPlayerAsync(int playerId)
        {
            return await _context.PlayerBonuses
                .Where(pb => pb.PlayerId == playerId)
                .Include(pb => pb.Bonus)
                .Select(pb => pb.Bonus)
                .ToListAsync();
        }

        public async Task<IEnumerable<Player>> GetPlayersForBonusAsync(int bonusId)
        {
            return await _context.PlayerBonuses
                .Where(pb => pb.BonusId == bonusId)
                .Include(pb => pb.Player)
                .Select(pb => pb.Player)
                .ToListAsync();
        }

        public async Task MarkBonusAsUsedAsync(int playerId, int bonusId)
        {
            var pb = await _context.PlayerBonuses
                .FirstOrDefaultAsync(x => x.PlayerId == playerId && x.BonusId == bonusId);

            if (pb != null)
            {
                pb.IsUsed = true;
                await _context.SaveChangesAsync();
            }
        }
    }

}
