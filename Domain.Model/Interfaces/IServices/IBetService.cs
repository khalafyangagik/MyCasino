using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Casino.Core.Models;

namespace Casino.Core.Interfaces.IServices
{
    public interface IBetService
    {
        Task<Bet> PlaceBetAsync(string gamename,int player_id, decimal amount);
        Task<IList<Bet>> GetAllBets(int id);
    
    }
}
