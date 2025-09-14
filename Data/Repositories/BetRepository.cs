using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Casino.Core.Interfaces.IRepositories;
using Casino.Core.Models;
using Data.DbContextFile;

namespace Data.Repositories
{
    public class BetRepository : IBetRepository
    {
        private CasinoDbContext _context;
        public BetRepository(CasinoDbContext context)
        {
            _context = context;
        }

        public async Task AddBet(Bet bet)
        {
            await _context.Bets.AddAsync(bet);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBet(Bet bet)
        {
            _context.Bets.Remove(bet);  
            await _context.SaveChangesAsync();
        }

        public async Task<Bet> GetBetById(int id)
        {
            return await _context.Bets.FindAsync(id);
           
        }

        public async Task Update(Bet bet)
        {
            _context.Bets.Update(bet);
            await _context.SaveChangesAsync();
        }
    }
}
