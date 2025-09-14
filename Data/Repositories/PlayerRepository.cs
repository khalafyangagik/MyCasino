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
    public class PlayerRepository : IPlayerRepository
    {
        private CasinoDbContext _context {  get; set; } 
        public PlayerRepository(CasinoDbContext context)
        {
            _context = context;
        }

        public async Task AddPlayer(Player player)
        {
            await _context.Players.AddAsync(player);
            await _context.SaveChangesAsync(); 
        }

        public async Task<Player> GetPlayer(int id)
        {
            return await _context.Players.FindAsync(id);
        }

        public async Task<IEnumerable<Player>> GetPlayers()
        {
            return await _context.Players.ToListAsync();
        }

        public async Task DeletePlayer(Player player)
        {
            _context.Players.Remove(player);
            await _context.SaveChangesAsync();
        }
    }
}
