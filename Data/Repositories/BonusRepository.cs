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
    public class BonusRepository : IRepository<Bonus>
    {
        private readonly CasinoDbContext _dbcontext;
        public BonusRepository(CasinoDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task Create(Bonus entity)
        {
            await _dbcontext.Bons.AddAsync(entity);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _dbcontext.Bons.FindAsync(id);
            if(entity == null)
            {
                throw new NullReferenceException();
            }

            _dbcontext.Bons.Remove(entity);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<Bonus> Get(int id)
        {
            return await _dbcontext.Bons.FindAsync(id);
        }

        public async Task Update(Bonus entity)
        {
            _dbcontext.Update(entity);
            await _dbcontext.SaveChangesAsync();
        }
    }
}
