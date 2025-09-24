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
    public class PlayerRepository : IRepository<Player>, IPlayerRepository
    {
        private CasinoDbContext _context {  get; set; }
        public PlayerRepository(CasinoDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task Create(Player player)
        {
            await _context.Players.AddAsync(player);
            await _context.SaveChangesAsync(); 
        }

        public async Task<Player> Get(int id)
        {
            return await _context.Players.FindAsync(id);
        }

        public async Task Delete(int id)
        {
            var player = await _context.Players.FindAsync(id);
            if(player == null)
            {
                throw new NullReferenceException(nameof(player));
            }

            _context.Players.Remove(player);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Player player)
        {
            _context.Players.Update(player);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Player?>> GetRichPlayers()
        {
            return await _context.Players.Include(x => x.Wallet).Where(x => x.Wallet != null && x.Wallet.Balance > 10000).ToListAsync();
        }
    }
}
