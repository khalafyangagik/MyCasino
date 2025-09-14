using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Casino.Core.Models;

namespace Casino.Core.Interfaces.IRepositories
{
    public interface IBetRepository
    {
        Task AddBet(Bet bet);  
        Task<Bet> GetBetById(int id);
        Task Update(Bet bet);
        Task DeleteBet(Bet bet);
    }
}
