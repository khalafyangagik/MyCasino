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
    public class BetRepository : IRepository<Bet>, IBetRepository
    {
        private CasinoDbContext _context;
        public BetRepository(CasinoDbContext context)
        {
            _context = context;
        }

        public async Task Create(Bet bet)
        {
            await _context.Bets.AddAsync(bet);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var bet = await _context.Bets.FindAsync(id);
            if (bet == null)
            {
                throw new NullReferenceException();
            }

            _context.Bets.Remove(bet);
            await _context.SaveChangesAsync();
        }

        public async Task<Bet> Get(int id)
        {
            return await _context.Bets.FindAsync(id);

        }

        public async Task Update(Bet bet)
        {
            _context.Bets.Update(bet);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<Bet>> GetAllBets(int userId)
        {
            var player = await _context.Players.AnyAsync(p => p.Id == userId);
            
            if (!player) 
            { 
                throw new NullReferenceException(); 
            }

            var bets = _context.Bets
                        .Where(b => b.PlayerId == userId)
                        .ToList();
            return bets;

        }
    }
}
