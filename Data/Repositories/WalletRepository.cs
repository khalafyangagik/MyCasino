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
    public class WalletRepository :IRepository<Wallet>
    {
        private CasinoDbContext _context;
        public WalletRepository(CasinoDbContext context)
        {
            _context = context;
        }

        public async Task Create(Wallet wallet)
        {
            await _context.Wallets.AddAsync(wallet);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var wallet = await _context.Wallets.FindAsync(id);
            if (wallet == null)
            {
                throw new Exception();
            }

            _context.Remove(wallet);
            await _context.SaveChangesAsync();
        }

        public async Task<Wallet> Get(int id)
        {
            return await _context.Wallets.FindAsync(id);  
        }

        public async Task Update(Wallet wallet)
        {
            _context.Update(wallet);
            await _context.SaveChangesAsync();
        }
    }
}
